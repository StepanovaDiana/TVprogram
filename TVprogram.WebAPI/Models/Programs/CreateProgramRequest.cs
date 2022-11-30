namespace TVprogram.WebAPI.Models;
public class CreateProgramRequest:UpdateProgramRequest
{
    public Guid ChannelId{get;set;}
}