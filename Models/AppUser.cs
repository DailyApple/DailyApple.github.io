using MessagePack;
using System.Runtime.InteropServices;

namespace DailyAppleAPI.Models;

public class AppUser
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleInitial { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid PracticeId { get; set; }
}
