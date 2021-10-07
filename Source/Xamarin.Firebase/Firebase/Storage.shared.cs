using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage : IFirebaseStorage
    {
        //void Setup(IFirebaseCore firebaseCore) => SetupInternal()
        public Task DownloadFileToLocalStorage(string filename) => DownloadFileToLocalStorageInternal(filename);
        public Task DownloadFileToMemory(string filename) => DownloadFileToMemoryInternal(filename);
        public Task UploadFile(byte[] data) => UploadFileInternal(data);
        public Task UploadFile(System.IO.Stream stream) => UploadFileInternal(stream);
        public Task UploadFile(string pathToLocalFile) => UploadFileInternal(pathToLocalFile);
        public Task DeleteFile(string filename) => DeleteFileInternal(filename);
        public Task<IEnumerable<string>> ListFiles(string path) => ListFilesInternal(path);
    }
}
