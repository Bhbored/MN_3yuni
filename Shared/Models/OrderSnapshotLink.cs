namespace Shared.Models;

public class OrderSnapshotLink
{
    public long Id { get; set; }
    public long Snapshot_Id { get; set; }
    public string Table_Name { get; set; } = default!;
    public string Row_Pk { get; set; } = default!;
    public DateTime Created_At { get; set; }
}
