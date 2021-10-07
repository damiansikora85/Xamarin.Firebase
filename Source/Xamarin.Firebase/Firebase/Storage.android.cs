using Java.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Storage;
using System.Linq;
using Android.Content;
using Android.App;

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

        private Task DownloadFileToLocalStorageInternal(string filename)
        {
            var tcs = new TaskCompletionSource<bool>();

            var storageRef = _firebaseStorage.GetReference("/");

            var pathReference = storageRef.Child(filename);
            File localFile = File.CreateTempFile(filename, "db");
            var listener = new FirebaseStorageListener<FileDownloadTask.TaskSnapshot>();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, snapshot) =>
            {
                tcs.SetResult(true);
            };

            pathReference.GetFile(localFile).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        private Task DownloadFileToMemoryInternal(string filename)
        {
            var tcs = new TaskCompletionSource<bool>();

            var storageRef = _firebaseStorage.GetReference("/");

            var pathReference = storageRef.Child(filename);
            var listener = new FirebaseStorageListenerByteArray();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, data) =>
            {
                tcs.SetResult(true);
            };

            pathReference.GetBytes(1024 * 1024 * 10).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        private Task UploadFileInternal(byte[] data)
        {
            throw new NotImplementedException();
        }

        private Task UploadFileInternal(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        private Task UploadFileInternal(string pathToLocalFile)
        {
            throw new NotImplementedException();
        }

        private Task DeleteFileInternal(string filename)
        {
            throw new NotImplementedException();
        }

        private Task<IEnumerable<string>> ListFilesInternal(string path)
        {
            var tcs = new TaskCompletionSource<IEnumerable<string>>();
            var listener = new FirebaseStorageListener<ListResult>();
            listener.OnFailEvent += (sender, exception) =>
            {
                tcs.SetException(exception);
            };
            listener.OnSuccessEvent += (sender, data) =>
            {
                var files = data.Items.Select(item => item.Name);
                tcs.SetResult(files);
            };
            var storageRef = _firebaseStorage.GetReference("/");
            storageRef.ListAll().AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }
    }
}
