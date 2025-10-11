using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MN_3yuni_MAUI.TestData
{
    public class PaymentTestDataGenerator
    {
        public Faker<Payment> CreatePaymentFakerForOrder(Order order)
        {
            return new Faker<Payment>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Order_Id, _ => order.Id)
                .RuleFor(p => p.Customer_Id, _ => order.User_Id)
                .RuleFor(p => p.Driver_Id, f => f.Random.Long(1, 100))
                .RuleFor(p => p.Amount_Items_Estimate, _ => order.Price_Estimate ?? 0)
                .RuleFor(p => p.Amount_Delivery_Fee, _ => order.Delivery_Fee_Quote ?? 0)
                .RuleFor(p => p.Amount_Tip, f => f.Random.Bool(0.4f) ? f.Finance.Amount(2, 20, 2) : null)
                .RuleFor(p => p.Amount_Penalty, f => f.Random.Bool(0.1f) ? f.Finance.Amount(5, 30, 2) : null)
                .RuleFor(p => p.Platform_Fee, f => f.Finance.Amount(1, 5, 2))
                .RuleFor(p => p.Escrow_Status, f =>
                    order.Status switch
                    {
                        Shared.Helpers.Enums.OrderStatus.Delivered => f.PickRandom(Shared.Helpers.Enums.EscrowStatus.Released, Shared.Helpers.Enums.EscrowStatus.Disputed),
                        Shared.Helpers.Enums.OrderStatus.Cancelled => Shared.Helpers.Enums.EscrowStatus.Refunded,
                        _ => Shared.Helpers.Enums.EscrowStatus.Hold
                    })
                .RuleFor(p => p.Provider, f => f.PickRandom("Stripe", "PayPal", "Cash"))
                .RuleFor(p => p.Provider_Payment_Intent_Id, f => f.Random.Bool(0.9f) ? f.Finance.Account(24) : null)
                .RuleFor(p => p.Created_At, _ => order.Created_At)
                .RuleFor(p => p.Updated_At, (f, p) => f.Date.Between(p.Created_At, DateTime.UtcNow))
                .RuleFor(p => p.Released_At, (f, p) =>
                    p.Escrow_Status == Shared.Helpers.Enums.EscrowStatus.Released ? f.Date.Between(p.Created_At, DateTime.UtcNow) : null)
                .RuleFor(p => p.Refunded_At, (f, p) =>
                    p.Escrow_Status == Shared.Helpers.Enums.EscrowStatus.Refunded ? f.Date.Between(p.Created_At, DateTime.UtcNow) : null);
        }
    }
}
