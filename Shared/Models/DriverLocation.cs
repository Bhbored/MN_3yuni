namespace Shared.Models;

public class DriverLocation
{
    public long Id { get; set; }
    public long Driver_Id { get; set; }
    public long? Order_Id { get; set; }
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    public decimal? Accuracy_M { get; set; }
    public decimal? Speed_M_S { get; set; }
    public DateTime Recorded_At { get; set; }
}
