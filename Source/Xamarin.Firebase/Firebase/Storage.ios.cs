using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage
    {
        private Task<string> DownloadFileToLocalStorageInternal(string path)
        {
            var tcs = new TaskCompletionSource<string>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(path);
            var filename = System.IO.Path.GetFileName(path);
            var destination = System.IO.Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), filename);
            var fileUrl = new NSUrl(destination);
            pathReference.WriteToFile(fileUrl, (url, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    tcs.SetResult(url.AbsoluteString);
                }
            });
            return tcs.Task;
        }

        private Task<byte[]> DownloadFileToMemoryInternal(string path)
        {
            var tcs = new TaskCompletionSource<byte[]>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(path);
            pathReference.GetData(1024 * 1024 * 10, (data, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    tcs.SetResult(data.ToArray());
                }
            });
            return tcs.Task;
        }

        private Task<long> UploadFileInternal(string firebasePath, byte[] data)
        {
            var tcs = new TaskCompletionSource<long>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(firebasePath);
            pathReference.PutData(NSData.FromArray(data), null, (result, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    tcs.SetResult(result.Size);
                }
            });
            return tcs.Task;
        }

        private Task<long> UploadFileInternal(string firebasePath, System.IO.Stream stream)
        {
            var tcs = new TaskCompletionSource<long>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(firebasePath);
            pathReference.PutData(NSData.FromStream(stream), null, (result, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    tcs.SetResult(result.Size);
                }
            });
            return tcs.Task;
        }

        private Task<long> UploadFileInternal(string firebasePath, string pathToLocalFile)
        {
            var tcs = new TaskCompletionSource<long>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(firebasePath);
            pathReference.PutFile(new NSUrl(pathToLocalFile), null, (result, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    tcs.SetResult(result.Size);
                }
            });
            return tcs.Task;
        }

        private async Task DeleteFileInternal(string firebasePath)
        {
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(firebasePath);
            await pathReference.DeleteAsync();
        }

        private Task<IEnumerable<FirebaseFile>> ListFilesInternal(string path)
        {
            var tcs = new TaskCompletionSource<IEnumerable<FirebaseFile>>();
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(path);
            pathReference.ListAll((result, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    var files = result.Items.Select(file => new FirebaseFile(file.Name, file.FullPath));
                    tcs.SetResult(files);
                }
            });
            return tcs.Task;
        }
    }
}
