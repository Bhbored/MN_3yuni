using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class OrderProof
    {
        public long Id { get; set; }
        public long Order_Id { get; set; }
        public ProofType Proof_Type { get; set; }
        public string Image_Url { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime Submitted_At { get; set; }
        public long Submitted_By_Driver_Id { get; set; }
        public bool Is_Approved { get; set; }
        public long? Approved_By_User_Id { get; set; }
        public DateTime? Approved_At { get; set; }

        public Order Order { get; set; } = default!;
    }
}
