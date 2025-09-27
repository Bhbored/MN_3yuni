using static Shared.Helpers.Enums;

namespace Shared.Models;

public class Payment
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public long Customer_Id { get; set; }
    public long Driver_Id { get; set; }
    public decimal Amount_Items_Estimate { get; set; }
    public decimal Amount_Delivery_Fee { get; set; }
    public decimal? Amount_Tip { get; set; }
    public decimal? Amount_Penalty { get; set; }
    public decimal Platform_Fee { get; set; }
    public EscrowStatus Escrow_Status { get; set; }
    public string Provider { get; set; } = default!;
    public string? Provider_Payment_Intent_Id { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public DateTime? Released_At { get; set; }
    public DateTime? Refunded_At { get; set; }
}
