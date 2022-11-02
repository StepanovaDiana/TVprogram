
namespace TVprogram.Entity.Models;
public class Channel:BaseEntity
{
    
    public string? Name{get;set;}
    public virtual ICollection<Programa>? Programs{get; set;}
    public virtual ICollection<Users_Channel_list>? UsersChannelList {get;set;}

}