using static Shared.Helpers.Enums;

namespace Shared.Models;

public class OrderSnapshot
{
    public long Id { get; set; }
    public long Order_Id { get; set; }
    public int Version { get; set; }
    public DateTime Taken_At { get; set; }
    public long? Taken_By_User_Id { get; set; }
    public EventType Reason { get; set; }
    public long? Event_Id { get; set; }
    public string Snapshot { get; set; } = default!;
    public string Snapshot_Sha256 { get; set; } = default!;
    public string? Storage_Uri { get; set; }
    public DateTime Created_At { get; set; }
}
