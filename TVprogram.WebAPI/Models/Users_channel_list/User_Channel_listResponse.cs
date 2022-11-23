namespace TVprogram.WebAPI.Models;
public class User_Channel_listResponse
{
    public Guid Id{get;set;}
     public bool Favorite_Channel {get;set;}
     public virtual Guid UserId{get;set;}
     public virtual Guid ChannelId{get;set;}
    
}