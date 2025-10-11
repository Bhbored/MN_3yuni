using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class Enums
    {
        public enum UserRole { Customer, Driver, Admin }
        public enum VehicleType { Bike, Motorbike, Car, Van }
        public enum WeightClass { Lt_1kg, _1_5kg, _5_10kg, _10_20kg, Gt_20kg }
        public enum SizeClass { Small, Medium, Large, Oversize }
        public enum OrderStatus
        {
            Available, Applied, Driver_Selected, Proof_Submitted,
            In_Transit, Arrived_Dropoff, Delivered_Pending_Confirm, Delivered, Cancelled
        }
        public enum ProofType { Receipt, Items_Photo, Other }
        public enum ApplicationStatus { Applied, Chatting, Blocked, Withdrawn, Selected, Not_Selected }
        public enum ChatStatus { Open, Blocked, Closed }
        public enum SenderType { Customer, Driver, Admin, System }
        public enum MessageType { Text, System, Location }
        public enum ReportStatus { Open, Reviewing, Resolved, Dismissed }
        public enum TicketType { Cancellation, Quality, Payment, Late_Penalty, Abuse, Other }
        public enum TicketStatus { Open, Investigating, Resolved, Closed }
        public enum RatingContext { Customer_Rates_Driver, Driver_Rates_Customer }
        public enum DeviceType { Android, Ios, Web }
        public enum NotifType
        {
            Order_Accepted_By_Driver, Order_Rejected_By_Driver, Driver_Selected_By_Customer,
            Driver_Not_Selected, Order_Cancelled, Driver_Arrived_At_Store, Proof_Submitted,
            Order_Picked_Up, Driver_On_Way, Order_Delivered, New_Message, Rating_Received,
            Wallet_Deposit, Wallet_Payment, Wallet_Refund, Order_Timeout, Driver_Location_Update
        }
        public enum NotifPriority { Low, Normal, High }
        public enum NotifCategory { Order, Chat, Wallet, System }
        public enum EscrowStatus { Hold, Released, Refunded, Disputed }
        public enum AttachmentType { Image, Video, Audio, Document, Other }
        public enum ConfirmMethod { Qr, Pin, Manual_Review }
        public enum EventRole { Customer, Driver, Admin, System }
        public enum EventType
        {
            Order_Created, Order_Updated, Order_Deleted,
            Driver_Applied, Driver_Blocked, Driver_Selected, Others_Auto_Closed,
            Chat_Opened, Chat_Message, Chat_Blocked,
            Proof_Submitted, Proof_Approved,
            In_Transit, Arrived_Dropoff,
            Delivery_Confirmed, Payment_Released, Payment_Refunded,
            Ticket_Opened, Ticket_Resolved
        }
        public enum WalletTxType { Deposit, Withdrawal, Payment, Refund, Earning, Fee, Tip, Adjustment }
        public enum WalletTxStatus { Pending, Completed, Failed, Cancelled }

    }
}
