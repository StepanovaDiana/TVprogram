using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TVprogram.Entity.Models;

namespace TVprogram.Entity;
public class Context : IdentityDbContext<User, UserRole, Guid>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Admin

        builder.Entity<Admin>().ToTable("admin");
        builder.Entity<Admin>().HasKey(x => x.Id);

        #endregion
         #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion

        #region Channels

        builder.Entity<Channel>().ToTable("channels");
        builder.Entity<Channel>().HasKey(x=>x.Id);

        #endregion

        #region User_Channel_list

        builder.Entity<Users_Channel_list>().ToTable("userChannelLists");
        builder.Entity<Users_Channel_list>().HasKey(x => x.Id);
        builder.Entity<Users_Channel_list>().HasOne(x=>x.User)
                                    .WithMany(x => x.UserChannelList)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Users_Channel_list>().HasOne(x => x.Channel)
                                    .WithMany(x => x.UsersChannelList)
                                    .HasForeignKey(x => x.ChannelId)
                                    .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Programs

        builder.Entity<Programa>().ToTable("programs");
        builder.Entity<Programa>().HasKey(x => x.Id);
        builder.Entity<Programa>().HasOne(x => x.Channel)
                                    .WithMany(x => x.Programs)
                                .HasForeignKey(x => x.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade);
        
        #endregion


    }
}


