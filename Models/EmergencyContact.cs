﻿namespace DailyAppleAPI.Models;
public class EmergencyContact
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Relation { get; set; }
}
