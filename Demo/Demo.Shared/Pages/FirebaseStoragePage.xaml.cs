using FirebaseDemo.Pages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Firebase;

namespace FirebaseDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirebaseStoragePage : ContentPage
    {
        public FirebaseStoragePageViewModel ViewModel => _viewModel;
        private FirebaseStoragePageViewModel _viewModel;

        public FirebaseStoragePage(IFirebaseStorage firebaseStorage)
        {
            _viewModel = new FirebaseStoragePageViewModel(firebaseStorage);
            InitializeComponent();
            BindingContext = _viewModel;
        }
    }
}