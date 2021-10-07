using System;

namespace FirebaseDemo.Droid.FirebaseImpl
{
    public class FirebaseStorageListenerByteArray : FirebaseStorageListener<byte[]>
    {
        public override event EventHandler<byte[]> OnSuccessEvent;

        public override void OnSuccess(Java.Lang.Object result)
        {
            OnSuccessEvent?.Invoke(this, (byte[])result);
        }
    }
}