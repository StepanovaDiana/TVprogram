
namespace TVprogram.Entity.Models;
public class Channel:BaseEntity
{
    public Guid IDChannel{get;set;}
    public string? Name{get;set;}
    public virtual ICollection<Programa>? Programs{get; set;}
    public virtual ICollection<Users_Channel_list>? UsersChannelList {get;set;}

}