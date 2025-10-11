using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ChatReport
    {
        public long Id { get; set; }

        public long ChatId { get; set; }               // FK → OrderChat.Id (assumed)
        public long ReporterId { get; set; }           // polymorphic (User/Driver) via ReporterType
        public string ReporterType { get; set; } = null!;
        public long ReportedId { get; set; }           // polymorphic via ReportedType
        public string ReportedType { get; set; } = null!;
        public string Reason { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = "open";   // or whatever default your SQL sets
        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }

        // Navs (best-guess)
        public OrderChat? Chat { get; set; }
    }
}
