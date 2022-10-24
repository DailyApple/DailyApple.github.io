namespace DailyAppleAPI.Models;
public class PatientInformation
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }  
    public double Weight { get; set; }  
    public char Sex { get; set; }
    public string? Race { get; set; }
    public string? BloodType { get; set; }
}
