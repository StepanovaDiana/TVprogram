namespace TVprogram.WebAPI.Models;
public class CreateUser_Channel_listRequest: UpdateUser_Channel_listRequest
{
    public Guid UserId{get;set;}
    public Guid ChannelId{get;set;}
}