using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Firebase.Plugin
{
    public interface IFirebaseCore
    {
        void Init();
        object GetApp();
    }
}
