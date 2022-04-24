using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Plugin.Firebase
{
    public interface IFirebaseCore
    {
        void Init();
        object GetApp();
    }
}
