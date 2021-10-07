using Android.Gms.Tasks;
using System;

namespace Xamarin.Plugin.Firebase
{
    internal class FirebaseCompleteListener<T> : Java.Lang.Object, IOnCompleteListener, IOnFailureListener
    {
        Action<T> _onComplete;
        public event EventHandler<Java.Lang.Exception> OnFailEvent;

        public FirebaseCompleteListener(Action<T> onComplete)
        {
            _onComplete = onComplete;
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            OnFailEvent?.Invoke(this, e);
        }

        public void OnComplete(Task task)
        {
            throw new NotImplementedException();
        }
    }
}