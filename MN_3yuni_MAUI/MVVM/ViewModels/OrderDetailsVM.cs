using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MN_3yuni_MAUI.TestData;
using Shared.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.MVVM.ViewModels
{
    public partial class OrderDetailsVM : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<OrderDisplayModel> allOrders;

        [ObservableProperty]
        private OrderDisplayModel currentOrder;

        [ObservableProperty]
        private ObservableCollection<OrderItemDisplay> orderItems;

        [ObservableProperty]
        private DriverDisplayModel assignedDriver;

        [ObservableProperty]
        private string pickupAddress;

        [ObservableProperty]
        private string dropoffAddress;

        [ObservableProperty]
        private string statusText;

        [ObservableProperty]
        private string statusDate;

        [ObservableProperty]
        private string deliveryFee;

        [ObservableProperty]
        private string totalPrice;

        [ObservableProperty]
        private int currentOrderIndex = 0;

        [ObservableProperty]
        private string orderCounter;

        public OrderDetailsVM()
        {

        }


        // Navigation Commands
        [RelayCommand]
        private void NextOrder()
        {
            if (AllOrders == null || AllOrders.Count == 0) return;

            CurrentOrderIndex = (CurrentOrderIndex + 1) % AllOrders.Count;
            LoadOrderDetails(AllOrders[CurrentOrderIndex]);
        }

        [RelayCommand]
        private void PreviousOrder()
        {
            if (AllOrders == null || AllOrders.Count == 0) return;

            CurrentOrderIndex = (CurrentOrderIndex - 1 + AllOrders.Count) % AllOrders.Count;
            LoadOrderDetails(AllOrders[CurrentOrderIndex]);
        }

        [RelayCommand]
        private void SelectOrder(OrderDisplayModel order)
        {
            var index = AllOrders.IndexOf(order);
            if (index >= 0)
            {
                CurrentOrderIndex = index;
                LoadOrderDetails(order);
            }
        }

        // Action Commands
        [RelayCommand]
        private async Task TrackOrder()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Tracking",
                $"Tracking order #{CurrentOrder.OriginalOrder.Id}...",
                "OK");
        }

        [RelayCommand]
        private async Task ContactDriver()
        {
            if (AssignedDriver != null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Contact Driver",
                    $"Opening chat with {AssignedDriver.Name}...",
                    "OK");
            }
        }

        [RelayCommand]
        private async Task CallDriver()
        {
            if (AssignedDriver != null)
            {
                var confirm = await Application.Current.MainPage.DisplayAlert(
                    "Call Driver",
                    $"Call {AssignedDriver.Name} at {AssignedDriver.PhoneNumber}?",
                    "Call", "Cancel");

                if (confirm)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Calling",
                        $"Calling {AssignedDriver.Name}...",
                        "OK");
                }
            }
        }

        [RelayCommand]
        private async Task ViewAllOrders()
        {
            if (AllOrders?.Count > 0)
            {
                var ordersList = string.Join("\n\n",
                    AllOrders.Select((order, index) =>
                        $"{index + 1}. {order.OrderNumber} - {order.Status}"));

                await Application.Current.MainPage.DisplayAlert(
                    "All Orders (5)",
                    ordersList,
                    "OK");
            }
        }


        public void Initialize(Order selectedOrder = null)
        {
            if (selectedOrder != null)
            {

                LoadSingleOrder(selectedOrder);
            }
            else
            {

                LoadTestData();
            }
            UpdateOrderCounter();
        }

        private void LoadSingleOrder(Order order)
        {
            var orderDisplay = MapToDisplayModel(order);
            AllOrders = new ObservableCollection<OrderDisplayModel> { orderDisplay };
            CurrentOrder = orderDisplay;
            LoadOrderDetails(orderDisplay);
        }

        private void LoadTestData()
        {

            var orderGenerator = new OrderTestDataGenerator();
            var testOrders = orderGenerator.Generate(5);

            // Map all orders to display models
            AllOrders = new ObservableCollection<OrderDisplayModel>(
                testOrders.Select(MapToDisplayModel).ToList()
            );

            // Load the first order
            if (AllOrders.Count > 0)
            {
                LoadOrderDetails(AllOrders[0]);
            }
        }

        private void LoadOrderDetails(OrderDisplayModel orderDisplay)
        {
            CurrentOrder = orderDisplay;
            var order = orderDisplay.OriginalOrder;


            PickupAddress = order.Pickup_Address_Text ?? "123 Fresh Foods Market, Springfield";
            DropoffAddress = order.Dropoff_Address_Text ?? "456 Home Address, Springfield";


            DeliveryFee = $"${order.Delivery_Fee_Quote:F2}";
            TotalPrice = $"${(order.Price_Estimate + order.Delivery_Fee_Quote):F2}";


            StatusText = GetStatusText(order.Status);
            StatusDate = GetStatusDate(order);


            LoadOrderItems(order);


            LoadDriverData(order);

            UpdateOrderCounter();
        }

        private OrderDisplayModel MapToDisplayModel(Order order)
        {
            var displayModel = new OrderDisplayModel
            {
                OrderNumber = $"Order #{order.Id}",
                TotalPrice = $"${order.Price_Estimate:F2}",
                Address = order.Dropoff_Address_Text,
                Status = GetStatusText(order.Status),
                OriginalOrder = order
            };

            try
            {
                var item = JsonSerializer.Deserialize<OrderItemJson>(order.OrderItem);
                displayModel.RestaurantInfo = $"{item?.name} • {item?.quantity} item(s)";
            }
            catch
            {
                displayModel.RestaurantInfo = "Order details";
            }

            return displayModel;
        }

        private void LoadOrderItems(Order order)
        {
            var items = new ObservableCollection<OrderItemDisplay>();

            try
            {
                var itemData = JsonSerializer.Deserialize<OrderItemJson>(order.OrderItem);
                if (itemData != null)
                {
                    items.Add(new OrderItemDisplay
                    {
                        Name = itemData.name,
                        Quantity = itemData.quantity,
                        Price = itemData.price,

                    });
                }
            }
            catch
            {

                items.Add(new OrderItemDisplay
                {
                    Name = "Fresh Groceries",
                    Quantity = 1,
                    Price = order.Price_Estimate ?? 0,
                    ImageUrl = "grocery_placeholder.png"
                });
            }


            if (items.Count == 1)
            {
                items.Add(new OrderItemDisplay
                {
                    Name = "Organic Produce Bundle",
                    Quantity = 1,
                    Price = 12.99m,
                    ImageUrl = "vegetables.png"
                });

                items.Add(new OrderItemDisplay
                {
                    Name = "Dairy Products",
                    Quantity = 2,
                    Price = 8.49m,
                    ImageUrl = "milk.png"
                });
            }

            OrderItems = items;
        }

        private void LoadDriverData(Order order)
        {

            var driverNames = new[] { "Ethan Carter", "Sarah Johnson", "Mike Chen", "David Rodriguez", "Lisa Wang" };
            var driverIndex = (int)(order.Id % 5);

            AssignedDriver = new DriverDisplayModel
            {
                Name = driverNames[driverIndex],
                Rating = 4.5 + (order.Id * 0.1),
                ReviewCount = 200 + (int)(order.Id * 65),
                ImageUrl = $"driver_{driverIndex + 1}.png",
                PhoneNumber = $"+1-555-01{order.Id:00}",
                VehicleType = order.Id % 2 == 0 ? "Toyota Prius" : "Honda Civic",
                LicensePlate = $"ABC{order.Id:000}"
            };
        }

        private string GetStatusText(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Delivered => "Delivered",
                OrderStatus.In_Transit => "In Transit",
                OrderStatus.Available => "Available",
                OrderStatus.Proof_Submitted => "Proof Submitted",
                OrderStatus.Arrived_Dropoff => "Arrived at Dropoff",
                OrderStatus.Cancelled => "Cancelled",
                _ => "Processing"
            };
        }

        private string GetStatusDate(Order order)
        {
            return order.Status switch
            {
                OrderStatus.Delivered => order.Delivered_Confirmed_At?.ToString("ddd, MMMM dd - h:mm tt") ?? "Recently",
                OrderStatus.In_Transit => order.In_Transit_At?.ToString("ddd, MMMM dd - h:mm tt") ?? "In progress",
                OrderStatus.Cancelled => order.Cancelled_At?.ToString("ddd, MMMM dd - h:mm tt") ?? "Recently",
                _ => order.Created_At.ToString("ddd, MMMM dd - h:mm tt")
            };
        }



        private void UpdateOrderCounter()
        {
            OrderCounter = $"{CurrentOrderIndex + 1} of {AllOrders?.Count ?? 0}";
        }


    }

    // Display Models 
    public class OrderItemDisplay
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string QuantityAndPrice => $"{Quantity} x ${Price:F2}";
        public decimal TotalPrice => Quantity * Price;
        public string DisplayTotal => $"${TotalPrice:F2}";
    }

    public class DriverDisplayModel
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public string LicensePlate { get; set; }

        public string RatingDisplay => $"{Rating:F1} ({ReviewCount} reviews)";
    }



}