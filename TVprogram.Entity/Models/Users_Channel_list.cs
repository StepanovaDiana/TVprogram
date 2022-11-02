
namespace TVprogram.Entity.Models;

public class Users_Channel_list:BaseEntity
{
    public virtual Guid UserId{get;set;}
    public virtual User? User{get;set;}
    public virtual Guid ChannelId{get;set;}
    public virtual Channel? Channel{get;set;}
    
    public bool FavoriteChannel{get; set;}
}
