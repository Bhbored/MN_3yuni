using static Shared.Helpers.Enums;

namespace Shared.Models;

public class DeliveryConfirmation
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public long Driver_Id { get; set; }
    public ConfirmMethod Method { get; set; }
    public long Confirmed_By_User_Id { get; set; }
    public decimal? Tip_Amount { get; set; }
    public DateTime Confirmed_At { get; set; }
}
