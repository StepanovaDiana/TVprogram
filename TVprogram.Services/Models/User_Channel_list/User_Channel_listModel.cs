using TVprogram.Entity.Models;
namespace TVprogram.Services.Models;
public class User_Channel_listModel:BaseModel
{
    public Guid Id{get;set;}
    public virtual Guid UserId{get;set;}
     public virtual Guid ChannelId{get;set;}
    public bool Favorite_Channel {get;set;}
}