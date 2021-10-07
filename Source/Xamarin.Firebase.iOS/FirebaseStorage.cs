using FirebaseDemo.Interfaces;
using Foundation;

namespace FirebaseDemo.iOS.FirebaseImpl
{
    public class FirebaseStorage : IFirebaseStorage
    {
        public void DownloadFileToLocalStorage(string filename)
        {
            var storageRef = Firebase.Storage.Storage.DefaultInstance.GetReferenceFromPath("/");
            var pathReference = storageRef.GetChild(filename);
            var fileUrl = new NSUrl("");
            pathReference.WriteToFile(fileUrl);
        }

        public void Setup(IFirebaseCore firebaseCore)
        {
            //nothing to do
        }
    }
}