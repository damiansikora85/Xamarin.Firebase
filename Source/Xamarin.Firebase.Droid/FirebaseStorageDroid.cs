using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Storage;
using FirebaseDemo.Interfaces;
using Java.IO;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDemo.Droid.FirebaseImpl.FirebaseStorageDroid))]
namespace FirebaseDemo.Droid.FirebaseImpl
{
    public class FirebaseStorageDroid : IFirebaseStorage
    {
        private Firebase.Storage.FirebaseStorage _firebaseStorage;

        public void Setup(IFirebaseCore firebaseCore)
        {
            _firebaseStorage = FirebaseStorage.GetInstance(firebaseCore.GetApp() as FirebaseApp);
        }

        public Task DownloadFileToLocalStorage(string filename)
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

        public Task DownloadFileToMemory(string filename)
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

            pathReference.GetBytes(1024*1024*10).AddOnSuccessListener(listener).AddOnFailureListener(listener);
            return tcs.Task;
        }

        public Task UploadFile(byte[] data)
        {
            throw new NotImplementedException();
        }

        public Task UploadFile(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task UploadFile(string pathToLocalFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ListFiles(string path)
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