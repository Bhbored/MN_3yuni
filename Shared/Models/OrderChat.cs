using static Shared.Helpers.Enums;

namespace Shared.Models;

public class OrderChat
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public long User_Id { get; set; }
    public long Driver_Id { get; set; }
    public ChatStatus Status { get; set; }
    public bool User_Blocked { get; set; }
    public bool Driver_Blocked { get; set; }
    public DateTime? Hidden_For_User_At { get; set; }
    public DateTime? Hidden_For_Driver_At { get; set; }
    public DateTime? Last_Message_At { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public ICollection<ChatReport> ChatReports { get; set; } = new List<ChatReport>();
    public Order Order { get; set; } = default!;
    public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
}
