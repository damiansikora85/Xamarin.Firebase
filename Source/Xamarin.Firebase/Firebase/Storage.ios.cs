using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Firebase.Plugin.Model;

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
            throw new NotImplementedException();
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
            var pathReference = global::Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath(path);
            pathReference.ListAll((result, error) =>
            {
                if (error != null)
                {
                    tcs.SetException(new Exception(error.Description));
                }
                else
                {
                    result.Items.Select(file => new FirebaseFile(file.Name, file.FullPath));
                }
            });
            return tcs.Task;
        }
    }
}
