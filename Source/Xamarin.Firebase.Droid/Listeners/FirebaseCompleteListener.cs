using Android.Gms.Tasks;
using System;
using Xamarin.Forms;

namespace FirebaseDemo.Droid.FirebaseImpl
{
    internal class FirebaseCompleteListener<T> : Java.Lang.Object, IOnCompleteListener, IOnFailureListener
    {
        Action<T> _onComplete;
        public event EventHandler<Java.Lang.Exception> OnFailEvent;

        public FirebaseCompleteListener(Action<T> onComplete)
        {
            _onComplete = onComplete;
        }

        public void OnComplete(Android.Gms.Tasks.Task completedTask)
        {
            if (completedTask.Result is T document)
            {
                _onComplete?.Invoke(document);
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            OnFailEvent?.Invoke(this, e);
        }
    }
}