using TVprogram.Entity.Models;
namespace TVprogram.Services.Models;
 public class ChannelModel:BaseModel
 {
   public Guid Id{get;set;}
    public string? Name{get;set;}
    
 }