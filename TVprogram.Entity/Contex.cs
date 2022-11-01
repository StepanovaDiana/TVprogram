using TVprogram.Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace TVprogram.Entitity;
public class Context:DbContext
{
    public DbSet<Admin>? Admin{get;set;}
    public DbSet<Channel>? Channels{get;set;}
    public DbSet<Programa>?  Programs{get;set;}
    public DbSet<User>? Users{get;set;}
    public DbSet<Users_Channel_list>? UserChannelLists{get;set;}
    public Context  (DbContextOptions<Context> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

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


