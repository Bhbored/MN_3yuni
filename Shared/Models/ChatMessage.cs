using static Shared.Helpers.Enums;

namespace Shared.Models;

public class ChatMessage
{
    public long Id { get; set; }
    public long Chat_Id { get; set; }
    public long Sender_Id { get; set; }
    public SenderType Sender_Type { get; set; }
    public MessageType Message_Type { get; set; }
    public string? Content { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool Is_Read { get; set; }
    public DateTime? Read_At { get; set; }
    public DateTime Created_At { get; set; }

    public OrderChat Chat { get; set; } = default!;
    public ICollection<ChatMessageAttachment> Attachments { get; set; } = new List<ChatMessageAttachment>();
}
