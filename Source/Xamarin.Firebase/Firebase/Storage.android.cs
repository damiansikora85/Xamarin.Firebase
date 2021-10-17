using Android.App;
using Firebase;
using Firebase.Storage;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Firebase.Plugin.Model;
using static Firebase.Storage.UploadTask;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage
    {
        private FirebaseStorage _firebaseStorage;

        public Storage()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            _firebaseStorage = FirebaseStorage.GetInstance(app);
        }

        private Task<string> DownloadFileToLocalStorageInternal(string path)
        {
            var tcs = new TaskCompletionSource<string>();

            var pathReference = _firebaseStorage.GetReference(path);
            var filename = System.IO.Path.GetFileNameWithoutExtension(path);
            var ext = System.IO.Path.GetExtension(path);
            File localFile = File.CreateTempFile(System.IO.Path.GetFileNameWithoutExtension(path), System.IO.Path.GetExtension(path));
            var listener = new FirebaseStorageListener<FileDownloadTask.TaskSnapshot>();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, snapshot) =>
            {
                tcs.SetResult(localFile.Path);
            };

            pathReference.GetFile(localFile).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        private Task<byte[]> DownloadFileToMemoryInternal(string path)
        {
            var tcs = new TaskCompletionSource<byte[]>();

            var pathReference = _firebaseStorage.GetReference(path);

            var listener = new FirebaseStorageListenerByteArray();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, data) =>
            {
                tcs.SetResult(data);
            };

            pathReference.GetBytes(1024 * 1024 * 10).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        private Task<long> UploadFileInternal(string firebasePath, byte[] data)
        {
            var tcs = new TaskCompletionSource<long>();
            var listener = new FirebaseStorageListener<TaskSnapshot>();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, result) =>
            {
                tcs.SetResult(result.BytesTransferred);
            };
            var pathReference = _firebaseStorage.GetReference(firebasePath);
            pathReference.PutBytes(data).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        private Task<long> UploadFileInternal(string firebasePath, System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        private Task<long> UploadFileInternal(string firebasePath, string pathToLocalFile)
        {
            throw new NotImplementedException();
        }

        private Task DeleteFileInternal(string filename)
        {
            throw new NotImplementedException();
        }

        private Task<IEnumerable<FirebaseFile>> ListFilesInternal(string path)
        {
            var tcs = new TaskCompletionSource<IEnumerable<FirebaseFile>>();
            var listener = new FirebaseStorageListener<ListResult>();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, data) =>
            {
                var files = data.Items.Select(item => new FirebaseFile(item.Name, item.Path));
                tcs.SetResult(files);
            };
            var storageRef = _firebaseStorage.GetReference(path);
            storageRef.ListAll().AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }
    }
}
