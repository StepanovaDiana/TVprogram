using TVprogram.Entity.Models;
namespace TVprogram.Services.Models;
 public class UserModel:BaseModel
 {
     public Guid Id { get; set; }
    public string Name{get;set;}
     public string? Email{get; set;}
   
 }