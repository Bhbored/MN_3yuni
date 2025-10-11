using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class OrderDriverApplication
    {
        public long Id { get; set; }
        public long Order_Id { get; set; }
        public long Driver_Id { get; set; }   // drivers.user_id
        public ApplicationStatus Status { get; set; }
        public DateTime Applied_At { get; set; }
        public DateTime? Blocked_At { get; set; }
        public DateTime? Rejected_At { get; set; }
        public string? Blocked_Reason { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        public Order Order { get; set; } = default!;
    }
}
