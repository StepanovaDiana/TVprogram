using TVprogram.Services.Models;
using IdentityModel.Client;
namespace TVprogram.Services.Abstract;
public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}
