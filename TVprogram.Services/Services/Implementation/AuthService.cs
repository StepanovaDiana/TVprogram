using AutoMapper;
using TVprogram.Entity.Models;
using TVprogram.Repository;
using TVprogram.Services.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TVprogram.Services.Abstract;
using TVprogram.Shared.Exceptions;
using TVprogram.Shared.ResultCodes;

namespace TVprogram.Services.Implementation;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IRepository<User> usersRepository;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    #endregion
    public AuthService(
        IRepository<User> usersRepository, UserManager<User> userManager, SignInManager<User> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        this.usersRepository = usersRepository;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }
    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = await userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var user = new User()
        {
            Email = model.Email,
            UserName = model.Email, // обязательно
            Name = model.Name ?? "",
            EmailConfirmed = true //to make it easier
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = await userManager.FindByEmailAsync(model.Email);
        return mapper.Map<UserModel>(createdUser);
    }

    public async Task<IdentityModel.Client.TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Email,
            Password = model.Password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        return tokenResponse;
    }
}