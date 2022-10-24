namespace DailyAppleAPI.Models;
public class PatientBiometrics
{
    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public string? Measurement { get; set; }
    public DateTime TimeTaken { get; set; }
}
