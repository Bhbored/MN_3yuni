namespace Shared.Models;

public class WalletAccount
{
    public long Id { get; set; }
    public long? User_Id { get; set; }
    public string Type { get; set; } = "main";
    public string Currency { get; set; } = "USD";
    public DateTime Created_At { get; set; }
}
