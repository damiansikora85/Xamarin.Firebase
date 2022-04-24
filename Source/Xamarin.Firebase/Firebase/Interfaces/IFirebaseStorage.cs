using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public interface IFirebaseStorage
    {
        Task<string> DownloadFileToLocalStorage(string filename);
        Task<byte[]> DownloadFileToMemory(string filename);
        Task<long> UploadFile(string firebasePath, byte[] data);
        Task<long> UploadFile(string firebasePath, System.IO.Stream stream);
        Task<long> UploadFile(string firebasePath, string pathToLocalFile);
        Task DeleteFile(string filename);
        Task<IEnumerable<FirebaseFile>> ListFiles(string path);
    }
}
