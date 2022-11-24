using TVprogram.Services.Abstract;
using TVprogram.Services.Implementation;
using TVprogram.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace TVprogram.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));
        //services
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IChannelService, ChannelService>();
        services.AddScoped<IProgramService, ProgramService>();
        services.AddScoped<IUser_Channel_listService, Users_Channel_listService>();
    }
}