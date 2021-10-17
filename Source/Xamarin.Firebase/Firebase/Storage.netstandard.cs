using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Firebase.Plugin.Model;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage
    {
        private Task<string> DownloadFileToLocalStorageInternal(string filename)
        {
            throw new NotImplementedException();
        }

        private Task<byte[]> DownloadFileToMemoryInternal(string filename)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
