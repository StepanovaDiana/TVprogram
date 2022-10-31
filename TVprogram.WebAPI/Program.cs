using TVprogram.WebAPI.AppConfigration.ServicesExtensions;
using TVprogram.WebAPI.AppConfigration.ApplicationExtensions; 
using Serilog;
using Microsoft.EntityFrameworkCore;
using TVprogram.Entities;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration();
//builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

app.Run();