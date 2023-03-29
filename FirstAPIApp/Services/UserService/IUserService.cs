using FirstAPIApp.Authentication;

namespace FirstAPIApp.Services.UserService
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
