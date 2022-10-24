namespace DailyAppleAPI.Models;
public class Patient
{
    public Guid Id { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Ssn { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
}
