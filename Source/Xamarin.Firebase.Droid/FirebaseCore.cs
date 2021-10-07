using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Storage;
using FirebaseDemo.Interfaces;
using Java.Interop;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDemo.Droid.FirebaseImpl.FirebaseCore))]
namespace FirebaseDemo.Droid.FirebaseImpl
{
    public class FirebaseCore : IFirebaseCore, IFirestoreDb
    {
        private FirebaseFirestore _firestoreDb;
        private FirebaseApp _firebaseApp;

        public void Init()
        {
            _firebaseApp = FirebaseApp.InitializeApp(Android.App.Application.Context);
            _firestoreDb = FirebaseFirestore.Instance;
        }

        public object GetApp()
        {
            return _firebaseApp;
        }

        public CollectionReference GetCollection(string collectionName)
        {
            return _firestoreDb.Collection(collectionName);
        }

        public DocumentReference GetDocument(string path)
        {
            return _firestoreDb.Document(path);
        }

        public void AddData(string collectionName, string documentName, object value)
        {
            //_firestoreDb.Collection(collectionName).Document(documentName).Set(value).AddOnCompleteListener(new FirebaseCompleteListener<DocumentReference>(document =>
            //{
                
            //}));
        }
    }
}