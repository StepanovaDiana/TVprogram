using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace TVprogram.WebAPI.AppConfigration.ServicesExtensions
{
    public static partial class ServicesExtensions
    {
        private static string AppTitle = "TVprogram Web API";
        /// <summary>
        /// Add swagger settings
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var provider= services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Version = description.GroupName,
                        Title = $"{AppTitle}",
                    });
                }

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //add xml file for api document
                var xmlFile = $"api.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });
        }
    }
}