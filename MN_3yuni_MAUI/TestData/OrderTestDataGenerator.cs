using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.TestData
{
    public class OrderTestDataGenerator
    {
        private readonly Faker<Order> _orderFaker;

        public OrderTestDataGenerator()
        {
            _orderFaker = new Faker<Order>()
                .RuleFor(o => o.Id, f => f.IndexFaker + 1)
                .RuleFor(o => o.User_Id, f => f.Random.Long(1, 1000))
                .RuleFor(o => o.OrderItem, f =>
                {
                    var item = new
                    {
                        name = f.Commerce.ProductName(),
                        quantity = f.Random.Int(1, 5),
                        price = f.Finance.Amount(10, 1000, 2),
                        description = f.Lorem.Sentence(5)
                    };
                    return JsonSerializer.Serialize(item);
                })
                .RuleFor(o => o.Price_Estimate, f => f.Finance.Amount(20, 2000, 2))
                .RuleFor(o => o.Delivery_Fee_Quote, f => f.Finance.Amount(3, 100, 2))
                .RuleFor(o => o.Pickup_Address_Text, f => f.Address.FullAddress())
                .RuleFor(o => o.Pickup_Lat, f => Convert.ToDecimal(f.Address.Latitude()))
                .RuleFor(o => o.Pickup_Lng, f => Convert.ToDecimal(f.Address.Longitude()))
                .RuleFor(o => o.Dropoff_Address_Text, f => f.Address.FullAddress())
                .RuleFor(o => o.Dropoff_Lat, f => Convert.ToDecimal(f.Address.Latitude()))
                .RuleFor(o => o.Dropoff_Lng, f => Convert.ToDecimal(f.Address.Longitude()))
                .RuleFor(o => o.Status, f => f.PickRandom<OrderStatus>())
                .RuleFor(o => o.Is_User_Edit_Locked, f => f.Random.Bool())
                .RuleFor(o => o.Is_Cancellable, f => f.Random.Bool(0.7f))
                .RuleFor(o => o.Created_At, f => f.Date.Past(30).ToUniversalTime())
                .RuleFor(o => o.Driver_Selected_At, (f, o) =>
                    o.Status >= OrderStatus.Available ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Proof_Approved_At, (f, o) =>
                    o.Status >= OrderStatus.Proof_Submitted ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.In_Transit_At, (f, o) =>
                    o.Status >= OrderStatus.In_Transit ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Arrived_Dropoff_At, (f, o) =>
                    o.Status >= OrderStatus.Arrived_Dropoff ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Delivered_Confirmed_At, (f, o) =>
                    o.Status == OrderStatus.Delivered ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Cancelled_At, (f, o) =>
                    o.Status == OrderStatus.Cancelled ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Updated_At, (f, o) => f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime());
        }

        public Order GenerateSingle()
        {
            return _orderFaker.Generate();
        }

        public List<Order> Generate(int count)
        {
            return _orderFaker.Generate(count);
        }

        public List<Order> GenerateWithStatuses(int count, params OrderStatus[] allowedStatuses)
        {
            return _orderFaker.Clone()
                .RuleFor(o => o.Status, f => f.PickRandom(allowedStatuses))
                .RuleFor(o => o.Created_At, f => f.Date.Recent(7).ToUniversalTime()) // last 7 days
                .RuleFor(o => o.Driver_Selected_At, (f, o) =>
                    o.Status >= OrderStatus.Available ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Proof_Approved_At, (f, o) =>
                    o.Status >= OrderStatus.Proof_Submitted ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.In_Transit_At, (f, o) =>
                    o.Status >= OrderStatus.In_Transit ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Arrived_Dropoff_At, (f, o) =>
                    o.Status >= OrderStatus.Arrived_Dropoff ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Delivered_Confirmed_At, (f, o) =>
                    o.Status == OrderStatus.Delivered ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .RuleFor(o => o.Cancelled_At, (f, o) =>
                    o.Status == OrderStatus.Cancelled ? f.Date.Between(o.Created_At, DateTime.UtcNow).ToUniversalTime() : (DateTime?)null)
                .Generate(count);
        }
        public Order GenerateSingle(Action<Order, Faker> configure)
        {
            return _orderFaker.Clone()
                .FinishWith((faker, order) => configure(order, faker))
                .Generate();
        }

        public List<Order> GenerateDelivered(int count)
        {
            return _orderFaker.Clone()
                .RuleFor(o => o.Status, _ => OrderStatus.Delivered)
                .RuleFor(o => o.Delivered_Confirmed_At, f => f.Date.Recent(7).ToUniversalTime())
                .Generate(count);
        }

    }
}
