using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Firebase.Plugin.Model
{
    public class FirebaseFile
    {
        public FirebaseFile(string file, string path)
        {
            Filename = file;
            Path = path;
        }

        public string Filename { get; set; }
        public string Path { get; set; }
    }
}
