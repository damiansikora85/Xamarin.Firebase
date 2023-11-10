using Xamarin.Plugin.Firebase;

namespace Demo.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAuthenticationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirebaseAuthenticationPage());
        }

        private async void OnStorageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirebaseStoragePage(new Storage()));
        }
    }
}