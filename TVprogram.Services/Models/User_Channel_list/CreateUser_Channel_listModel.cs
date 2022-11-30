
namespace TVprogram.Services.Models;
public class CreateUser_Channel_listModel
{

    public virtual Guid UserId{get;set;}
     public virtual Guid ChannelId{get;set;}
    public bool Favorite_Channel {get;set;}
}