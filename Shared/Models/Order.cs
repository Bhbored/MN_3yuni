using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long User_Id { get; set; }
        //public long? Assigned_Driver_Id { get; set; }
        public string OrderItem { get; set; } = "{}"; // JSON as string; map via Npgsql JSON later
        //public long? Category_Id { get; set; }
        //public WeightClass? Weight_Class { get; set; }
        //public decimal? Weight_Kg_Min { get; set; }
        //public decimal? Weight_Kg_Max { get; set; }
        //public SizeClass? Size_Class { get; set; }
        public decimal? Price_Estimate { get; set; }
        public decimal? Delivery_Fee_Quote { get; set; }
        public string Pickup_Address_Text { get; set; } = default!;
        public decimal Pickup_Lat { get; set; }
        public decimal Pickup_Lng { get; set; }
        public string Dropoff_Address_Text { get; set; } = default!;
        public decimal Dropoff_Lat { get; set; }
        public decimal Dropoff_Lng { get; set; }
        public OrderStatus Status { get; set; }
        public bool Is_User_Edit_Locked { get; set; }
        public bool Is_Cancellable { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Driver_Selected_At { get; set; }
        public DateTime? Proof_Approved_At { get; set; }
        public DateTime? In_Transit_At { get; set; }
        public DateTime? Arrived_Dropoff_At { get; set; }
        public DateTime? Delivered_Confirmed_At { get; set; }
        public DateTime? Cancelled_At { get; set; }
        public DateTime Updated_At { get; set; }

        //public User Customer { get; set; } = default!;
        //public User? AssignedDriver { get; set; }
        public ItemCategory? Category { get; set; }
        //public ICollection<OrderProof> Proofs { get; set; } = new List<OrderProof>();
        //public ICollection<OrderDriverApplication> Applications { get; set; } = new List<OrderDriverApplication>();
        //public ICollection<OrderChat> Chats { get; set; } = new List<OrderChat>();
    }
}
