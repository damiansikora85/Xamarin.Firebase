using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public interface IFirebaseStorage
    {
        //void Setup(IFirebaseCore firebaseCore);
        Task DownloadFileToLocalStorage(string filename);
        Task DownloadFileToMemory(string filename);
        Task UploadFile(byte[] data);
        Task UploadFile(System.IO.Stream stream);
        Task UploadFile(string pathToLocalFile);
        Task DeleteFile(string filename);
        Task<IEnumerable<string>> ListFiles(string path);
    }
}
