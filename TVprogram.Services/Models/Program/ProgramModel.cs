using TVprogram.Entity.Models;
namespace TVprogram.Services.Models;
public class ProgramModel:BaseModel
{
    public Guid Id{get;set;}
    public string Name {get;set;}
    public int Duration{get;set;}
    public DateTime Time{get;set;}
    public virtual Guid ChannelId{get;set;}
}