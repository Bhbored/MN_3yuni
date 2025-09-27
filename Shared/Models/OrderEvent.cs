using static Shared.Helpers.Enums;

namespace Shared.Models;

public class OrderEvent
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public long? Actor_User_Id { get; set; }
    public EventRole Actor_Role { get; set; }
    public EventType Event_Type { get; set; }
    public string? Metadata { get; set; }
    public DateTime Created_At { get; set; }
}
