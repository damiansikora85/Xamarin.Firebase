using FirebaseDemo.Interfaces;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Firebase;
using FirebaseDemo.Model;

namespace FirebaseDemo.iOS.FirebaseImpl
{
    public class FirebaseAuthentication : NSObject, IFirebaseAuth
    {
        public async Task<User> CreateAccount(string email, string password)
        {
            var result = await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
            return new User(result.User.DisplayName, result.User.Email);
        }

        public User GetCurrentUser()
        {
            var user = Firebase.Auth.Auth.DefaultInstance.CurrentUser;
            if(user != null)
            {
                return new User(user.DisplayName, user.Email);
            }
            return null;
        }

        public async Task SendPasswordResetEmail(string email)
        {
            await Firebase.Auth.Auth.DefaultInstance.SendPasswordResetAsync(email);
        }

        public async Task<User> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var result = await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return new User(result.User.DisplayName, result.User.Email);
            }
            catch (Exception exc)
            {
                var msg = exc.Message;
                //invalid credentials (password)
                return null;
            }
        }
    }
}