using Firebase;
using Firebase.Auth;
using Firebase.Firestore.Auth;
using FirebaseDemo.Interfaces;
using FirebaseDemo.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Firebase.Plugin;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDemo.Droid.FirebaseImpl.FirebaseAuthentication))]
namespace FirebaseDemo.Droid.FirebaseImpl
{
    public class FirebaseAuthentication : IFirebaseAuth
    {
        public async Task<User> CreateAccount(string email, string password)
        {
            try
            {
                var auth = FirebaseAuth.Instance;
                var result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
                return new User(result.User.DisplayName, result.User.Email);
            }
            catch (FirebaseAuthWeakPasswordException)
            {
                //password is too weak (6 characters min)
                return null;
            }
            catch(FirebaseAuthUserCollisionException)
            {
                // email address already in use
                return null;
            }
        }

        public User GetCurrentUser()
        {
            if(FirebaseAuth.Instance.CurrentUser != null)
            {
                var user = FirebaseAuth.Instance.CurrentUser;
                return new User(user.DisplayName, user.Email);
            }
            return null;
        }

        public async Task<User> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var auth = FirebaseAuth.Instance;
                var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
                return new User(result.User.DisplayName, result.User.Email);
            }
            catch(FirebaseAuthInvalidCredentialsException)
            {
                //invalid credentials (password)
                return null;
            }
            catch(FirebaseAuthInvalidUserException)
            {
                //user does not exist, wrong email
                return null;
            }
        }

        public async Task SendPasswordResetEmail(string email)
        {
            try
            {
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
            }
            catch(FirebaseAuthInvalidUserException)
            {
                //invalid user
            }
        }
    }
}