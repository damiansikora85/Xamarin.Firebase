using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirebaseDemo.Droid.FirebaseImpl
{
    public class FirebaseStorageListener<T> : Java.Lang.Object, IOnSuccessListener, IOnFailureListener
    {
        public event EventHandler<Java.Lang.Exception> OnFailEvent;
        public virtual event EventHandler<T> OnSuccessEvent;
        public void OnFailure(Java.Lang.Exception e)
        {
            OnFailEvent?.Invoke(this, e);
        }

        public virtual void OnSuccess(Java.Lang.Object result)
        {
            if (result is T resultCasted)
            {
                OnSuccessEvent?.Invoke(this, resultCasted);
            }
        }
    }
}