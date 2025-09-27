namespace Shared.Models;

public class DeliveryPenalty
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public int Minutes_Late { get; set; }
    public decimal Penalty_Amount { get; set; }
    public string Policy_Version { get; set; } = default!;
    public DateTime Calculated_At { get; set; }
}
