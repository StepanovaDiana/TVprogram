namespace TVprogram.Entity.Models;
public class Programa:BaseEntity
{
    public virtual Guid ChannelId{get;set;}
    public virtual Channel? Channel{get;set;}
    public string? Name{get;set;}
    public DateTime DateTime{get;set;}
    public int Duration{get;set;}
    
}