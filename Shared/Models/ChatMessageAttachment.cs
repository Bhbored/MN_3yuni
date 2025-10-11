using static Shared.Helpers.Enums;

namespace Shared.Models;

public class ChatMessageAttachment
{
    public long Id { get; set; }
    public long Message_Id { get; set; }
    public string Attachment_Url { get; set; } = default!;
    public AttachmentType Attachment_Type { get; set; }
    public string? Mime_Type { get; set; }
    public long? Size_Bytes { get; set; }
    public int? Width_Px { get; set; }
    public int? Height_Px { get; set; }
    public int? Duration_Ms { get; set; }
    public int Sequence_Index { get; set; }
    public DateTime Created_At { get; set; }

    public ChatMessage Message { get; set; } = default!;
}
