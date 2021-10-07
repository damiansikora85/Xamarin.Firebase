using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Firebase.Plugin.Model;
using Xamarin.Plugin.Firebase;

namespace FirebaseDemo.Pages.ViewModels
{
    public class FirebaseStoragePageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<FirebaseFile> Files { get; private set; }
        public ICommand UploadFromMemoryCommand { get; }
        public ICommand UploadFromLocalFileCommand { get; }
        public ICommand ListStorageCommand { get; }
        public ICommand DownloadToMemoryCommand { get; }
        public ICommand DownloadToLocalFileCommand { get; }
        public ICommand DeleteFileCommand { get; }
        public string FirebasePath { get; set; } = "/";

        private IFirebaseStorage _firebaseStorage;

        public FirebaseStoragePageViewModel(IFirebaseStorage firebaseStorage)
        {
            _firebaseStorage = firebaseStorage;
            UploadFromMemoryCommand = new Command(UploadFromMemory);
            UploadFromLocalFileCommand = new Command(UploadFromLocalFile);
            ListStorageCommand = new AsyncCommand(ListStorage);
            DownloadToMemoryCommand = new AsyncCommand<FirebaseFile>(DownloadFileToMemory);
            DownloadToLocalFileCommand = new AsyncCommand<FirebaseFile>(DownloadFileToLocalFile);
            DeleteFileCommand = new AsyncCommand<FirebaseFile>(DeleteFile);

            Files = new ObservableRangeCollection<FirebaseFile>();
            //{
            //    new FirebaseFile("test1.txt"),
            //    new FirebaseFile("test2.txt"),
            //    new FirebaseFile("test3.txt"),
            //    new FirebaseFile("test4.txt"),
            //};
        }

        private async Task DeleteFile(FirebaseFile file)
        {
            await _firebaseStorage.DeleteFile(file.Filename);
        }

        private async Task DownloadFileToLocalFile(FirebaseFile file)
        {
            await _firebaseStorage.DownloadFileToLocalStorage(file.Filename);
        }

        private async Task DownloadFileToMemory(FirebaseFile file)
        {
            await _firebaseStorage.DownloadFileToMemory(file.Filename);
        }

        private async Task ListStorage()
        {
            var result = await _firebaseStorage.ListFiles(FirebasePath);
            var files = new List<FirebaseFile>();
            foreach(var file in result)
            {
                files.Add(new FirebaseFile(file));
            }
            Files.AddRange(files);
        }

        private void UploadFromLocalFile()
        {
            throw new NotImplementedException();
        }

        private void UploadFromMemory()
        {
            throw new NotImplementedException();
        }
    }
}
