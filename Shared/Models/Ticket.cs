using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Ticket
    {
        public long Id { get; set; }

        public long OrderId { get; set; }                  // FK → Order.Id
        public long ReporterId { get; set; }               // polymorphic via ReporterType
        public string ReporterType { get; set; } = null!;
        public long ReportedId { get; set; }               // polymorphic via ReportedType
        public string ReportedType { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? EvidenceImageUrl { get; set; }
        public string Status { get; set; } = "open";
        public long? PaymentId { get; set; }               // FK → Payments.Id (nullable)
        public string? Resolution { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public long? ResolvedByAdminId { get; set; }       // FK → Users.Id (nullable)

        public Order? Order { get; set; }
        public Payment? Payment { get; set; }
        public User? ResolvedByAdmin { get; set; }
    }
}
