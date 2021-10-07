using Xamarin.Firebase.Plugin;
using Xamarin.Forms;
using Xamarin.Plugin.Firebase;

namespace FirebaseDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var firebaseCore = DependencyService.Get<IFirebaseCore>();
            //firebaseCore.Init();
            //DependencyService.Get<IFirebaseStorage>().Setup(firebaseCore);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
