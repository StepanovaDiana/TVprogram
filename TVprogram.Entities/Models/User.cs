namespace TVprogram.Entities.Models;

public class User:BaseEntity
{
    public Guid IDUser{get;set;}
    public string Name{get; set;}
    public string Email{get; set;}
    public string PasswordHash{get;set;}
    public virtual ICollection<Users_Channel_list> UserChannelList {get;set;}
    
}