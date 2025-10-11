using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MN_3yuni_MAUI.TestData;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.MVVM.ViewModels
{
    public partial class OrderVM : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<OrderDisplayModel> displayedOrders;

        [ObservableProperty]
        private bool isUpcomingSelected = true;

        private List<OrderDisplayModel> upcomingOrders;
        private List<OrderDisplayModel> pastOrders;

        public OrderVM()
        {
            LoadTestData();
            UpdateDisplayedOrders();
        }


        //replay Commands
        [RelayCommand]
        private void SelectUpcoming()
        {
            IsUpcomingSelected = true;
            UpdateDisplayedOrders();
        }

        [RelayCommand]
        private void SelectPast()
        {
            IsUpcomingSelected = false;
            UpdateDisplayedOrders();
        }

        [RelayCommand]
        private async Task GoToOrderDetails(OrderDisplayModel order)
        {
            if (order != null && order.OriginalOrder != null)
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    { "SelectedOrder", order.OriginalOrder }
                };

                await Shell.Current.GoToAsync(nameof(Views.OrderDetails), navigationParameter);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Order data is not available", "OK");
            }
        }



        private static readonly OrderStatus[] UpcomingStatuses = {
            OrderStatus.Available,
            OrderStatus.Proof_Submitted,
            OrderStatus.In_Transit,
            OrderStatus.Arrived_Dropoff
        };

        private static readonly OrderStatus[] PastStatuses = {
            OrderStatus.Delivered,
            OrderStatus.Cancelled
        };

        //load function
        private void LoadTestData()
        {
            var orderGenerator = new OrderTestDataGenerator();
            var paymentGenerator = new PaymentTestDataGenerator();

            upcomingOrders = orderGenerator
                  .GenerateWithStatuses(5, UpcomingStatuses)
                  .Select(MapToDisplayModel)
                  .ToList();


            pastOrders = orderGenerator
                .GenerateWithStatuses(4, PastStatuses)
                .Select(MapToDisplayModel)
                .ToList();
        }

        //mapping fields
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

        private string GetStatusText(Shared.Helpers.Enums.OrderStatus status)
        {
            return status switch
            {
                Shared.Helpers.Enums.OrderStatus.Delivered => "Delivered",
                Shared.Helpers.Enums.OrderStatus.In_Transit => "Expected in 25 min",
                Shared.Helpers.Enums.OrderStatus.Available => "Driver being assigned",
                Shared.Helpers.Enums.OrderStatus.Proof_Submitted => "Proof submitted",
                Shared.Helpers.Enums.OrderStatus.Arrived_Dropoff => "Driver arrived",
                Shared.Helpers.Enums.OrderStatus.Cancelled => "Cancelled",
                _ => "Processing"
            };
        }



        private void UpdateDisplayedOrders()
        {
            DisplayedOrders = new ObservableCollection<OrderDisplayModel>(
                IsUpcomingSelected ? upcomingOrders : pastOrders
            );
        }



    }

    //models mapping
    public class OrderItemJson
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }

    public class OrderDisplayModel
    {
        public string OrderNumber { get; set; }
        public string TotalPrice { get; set; }
        public string RestaurantInfo { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public Order OriginalOrder { get; set; }
    }
}
