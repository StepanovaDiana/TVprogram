using Serilog;

namespace TVprogram.WebAPI.AppConfigration.ApplicationExtensions
{
    public static partial class ApplicationExtensions
    {
        /// <summary>
        /// Use serilog configuration
        /// </summary>
        /// <param name="app"></param>
        public static void  UseSerilogConfiguration(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}