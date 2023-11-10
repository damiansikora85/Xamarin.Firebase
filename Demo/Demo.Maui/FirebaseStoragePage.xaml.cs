using Xamarin.Plugin.Firebase;

namespace Demo.Maui;

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