using TVprogram.Repository;
using TVprogram.Services;
using TVprogram.WebAPI.AppConfiguration.ServicesExtensions;
using TVprogram.WebAPI.AppConfiguration.ApplicationExtensions;
using Serilog;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddMapperConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositoryConfiguration();
builder.Services.AddBusinessLogicConfiguration();


var app = builder.Build();

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}