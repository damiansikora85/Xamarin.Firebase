using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Firebase.Plugin.Model
{
    public class FirebaseFile
    {
        public FirebaseFile(string file)
        {
            Filename = file;
        }

        public string Filename { get; set; }
    }
}
