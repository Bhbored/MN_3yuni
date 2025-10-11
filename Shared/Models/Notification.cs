using static Shared.Helpers.Enums;

namespace Shared.Models;

public class Notification
{
    public long Id { get; set; }
    public long Recipient_Id { get; set; }
    public long? Sender_Id { get; set; }
    public NotifType Notification_Type { get; set; }
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public long? Order_Id { get; set; }
    public long? Reference_Id { get; set; }
    public string? Reference_Type { get; set; }
    public NotifPriority Priority { get; set; }
    public NotifCategory Category { get; set; }
    public bool Is_Read { get; set; }
    public bool Is_Sent_Push { get; set; }
    public DateTime? Sent_At { get; set; }
    public DateTime? Read_At { get; set; }
    public DateTime Created_At { get; set; }
    public string? Metadata { get; set; }
}
