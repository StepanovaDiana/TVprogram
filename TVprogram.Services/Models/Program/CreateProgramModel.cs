
namespace TVprogram.Services.Models;
public class CreateProgramModel
{

    public string Name {get;set;}
    public int Duration{get;set;}
    public DateTime Time{get;set;}
    public virtual Guid ChannelId{get;set;}
}