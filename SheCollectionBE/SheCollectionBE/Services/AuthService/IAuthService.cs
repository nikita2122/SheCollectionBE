using SheCollectionBE.Request_Models;
using SheCollectionBE.Response_Models;

namespace SheCollectionBE.Services.AuthService
{
    public interface IAuthService
    {
        AuthenticatedResponse? Login(LoginModel model);
        AuthenticatedResponse? Register(RegisterModel model);
        bool UpdateAccount(UpdateAccount model);
        bool UpdatePassword(UpdatePasswordModel passwdModel);
        bool ResetPassword(string email, string password);
    }
}
