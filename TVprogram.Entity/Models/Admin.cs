namespace TVprogram.Entity.Models;
public class Admin:BaseEntity
{
    public Guid IDAdmin{get;set;}
    public string? Login{get; set;}
    public string? PasswordHash{get; set;}
}
