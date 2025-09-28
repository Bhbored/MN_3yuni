using static Shared.Helpers.Enums;

namespace Shared.Models;

public class WalletTransaction
{
    public long Id { get; set; }
    //public long Account_Id { get; set; }
    //public long? Counterparty_Account_Id { get; set; }
    public WalletTxType Transaction_Type { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    //public string? Reference_Number { get; set; }
    //public string? Reference_Type { get; set; }
    //public long? Reference_Id { get; set; }
    public WalletTxStatus Status { get; set; } = WalletTxStatus.Completed;
    public DateTime Created_At { get; set; }
}
