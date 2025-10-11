using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class Driver
    {
        public long Id { get; set; }
        //public long User_Id { get; set; }
        //public string License_Number { get; set; } = default!;
        public bool Is_Verified { get; set; }
        public decimal Rating_Average { get; set; }
        public int Total_Deliveries { get; set; }
        public VehicleType? Vehicle_Type { get; set; }
        //public int Working_Radius_Km { get; set; }
        //public DateTime Created_At { get; set; }
        //public DateTime Updated_At { get; set; }

        //public User User { get; set; } = default!;
    }
}
