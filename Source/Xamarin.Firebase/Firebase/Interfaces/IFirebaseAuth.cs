using System.Threading.Tasks;

namespace Xamarin.Plugin.Firebase
{
    public interface IFirebaseAuth
    {
        FirebaseUser GetCurrentUser();
        Task<FirebaseUser> LoginWithEmailPassword(string email, string password);
        Task<FirebaseUser> CreateAccount(string email, string password);
        Task SendPasswordResetEmail(string email);
    }
}
