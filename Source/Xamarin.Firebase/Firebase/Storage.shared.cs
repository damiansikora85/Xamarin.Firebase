using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Firebase.Plugin.Model;

namespace Xamarin.Plugin.Firebase
{
    public partial class Storage : IFirebaseStorage
    {
        public Task<string> DownloadFileToLocalStorage(string filename) => DownloadFileToLocalStorageInternal(filename);
        public Task<byte[]> DownloadFileToMemory(string filename) => DownloadFileToMemoryInternal(filename);
        public Task<long> UploadFile(string firebasePath, byte[] data) => UploadFileInternal(firebasePath, data);
        public Task<long> UploadFile(string firebasePath, System.IO.Stream stream) => UploadFileInternal(firebasePath, stream);
        public Task<long> UploadFile(string firebasePath, string pathToLocalFile) => UploadFileInternal(firebasePath, pathToLocalFile);
        public Task DeleteFile(string filename) => DeleteFileInternal(filename);
        public Task<IEnumerable<FirebaseFile>> ListFiles(string path) => ListFilesInternal(path);
    }
}
