namespace DailyAppleAPI.Models;
public class Practice
{
    public Guid Id { get; set; }
    public string? PracticeName { get; set; }
    public string? Url { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
}
