using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage
    {
        private Task DownloadFileToLocalStorageInternal(string filename)
        {
            throw new NotImplementedException();
        }

        private Task DownloadFileToMemoryInternal(string filename)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
