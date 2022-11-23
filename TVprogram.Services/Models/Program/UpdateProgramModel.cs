using TVprogram.Entity.Models;
namespace TVprogram.Services.Models;
public class UpdateProgramModel
{
    public string Name {get;set;}
    public int Duration{get;set;}
    public DateTime Time{get;set;}
}