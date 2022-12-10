using System;
using TVprogram.Entity;
using TVprogram.Entity.Models;
using TVprogram.Services.Abstract;
using TVprogram.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TVprogram.WebAPI.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "master@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "zaq11qaz";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterUserModel()
        {
            Email = MASTER_ADMIN_EMAIL,
            Password = MASTER_ADMIN_PASSWORD,
           // Role = Entity.Models.Role.Admin
        });
    }

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
           
            
            var userRepository = (IRepository<User>)scope.ServiceProvider.GetRequiredService(typeof(IRepository<User>));
            var user =  userRepository.GetAll().Where(x => x.Email == MASTER_ADMIN_EMAIL).FirstOrDefault();
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}