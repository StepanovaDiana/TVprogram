using TVprogram.WebAPI.MapperProfile;

namespace TVprogram.WebAPI.AppConfiguration.ServicesExtensions;

public static partial class ServicesExtensions
{
    /// <summary>
    /// Add serilog configuration
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PresentationProfile));
    }

}