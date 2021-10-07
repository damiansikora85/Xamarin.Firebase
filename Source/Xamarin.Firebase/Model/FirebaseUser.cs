using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Firebase.Plugin.Model
{
    public class FirebaseUser
    {
        public string DisplayName { get; }
        public string Email { get; }

        public FirebaseUser(string name, string email)
        {
            DisplayName = name;
            Email = email;
        }
    }
}
