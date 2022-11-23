namespace TVprogram.WebAPI.Models;
public class ProgramPreviewResponse
{
     public Guid Id { get; set; }
     public string Name { get; set; }
    public int Duration{get;set;}
    public DateTime Time{get;set;}
}