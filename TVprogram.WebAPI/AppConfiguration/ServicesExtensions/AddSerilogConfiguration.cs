using Serilog;
namespace TVprogram.WebAPI.AppConfigration.ServicesExtensions
{
    /// <summary>
    /// Services extensions
    /// </summary>
     public static partial class ServicesExtensions
    {
       /// <summary>
    /// Application builder extensions
    /// </summary>
        public static void AddSerilogConfiguration(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddHttpContextAccessor();
        }
    }
}