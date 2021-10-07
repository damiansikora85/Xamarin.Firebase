using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Plugin.Firebase;

namespace FirebaseDemo
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
