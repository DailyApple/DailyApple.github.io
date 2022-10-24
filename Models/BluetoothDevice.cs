namespace DailyAppleAPI.Models;
public class BluetoothDevice
{
    public Guid Id { get; set; }
    public string? DeviceName { get; set; }
    public string? DeviceType { get; set; }
    public string? Description { get; set; }
    public bool? isConnected { get; set; }
}
