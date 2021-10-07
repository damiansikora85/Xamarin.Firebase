using FirebaseDemo.Interfaces;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Firebase;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDemo.iOS.FirebaseImpl.FirebaseCore))]
namespace FirebaseDemo.iOS.FirebaseImpl
{
    public class FirebaseCore : IFirebaseCore
    {
        public object GetApp()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            Firebase.Core.App.Configure();
        }
    }
}