using CommunityToolkit.Mvvm.ComponentModel;
using MN_3yuni_MAUI.TestData;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MN_3yuni_MAUI.MVVM.ViewModels
{
    // Custom Driver class for the UI
    public class DriverItem
    {
        public string FirstName { get; set; }
        public double Rating { get; set; }
        public bool IsOnline { get; set; }
    }

    // Custom Order class for the UI
    public class OrderItem
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string ETA { get; set; }
        public string Status { get; set; }
        public DriverItem Driver { get; set; }
    }
    public partial class HomeVM : ObservableObject
    {
        public HomeVM()
        {
            generateTestDate();
        }
        #region Properties

        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private List<WalletTransaction> _transactions;

        [ObservableProperty]
        private ObservableCollection<DriverItem> recentDrivers;

        [ObservableProperty]
        private ObservableCollection<WalletTransaction> recentActivity;

        [ObservableProperty]
        private OrderItem activeOrder;

        [ObservableProperty]
        private string savedAddress;
        #endregion

        #region Commands
        #endregion

        #region Methods

        public void generateTestDate()
        {
            user = new User
            {
                FirstName = "Olivia",
                WalletBalance = (decimal?)125.50
            };

            // Generate test transactions
            var generator = new WalletTransactionTestDataGenerator();
            var testTransactions = generator.Generate(50);
            _transactions = new List<WalletTransaction>();
            foreach (var item in testTransactions)
            {
                Transactions.Add(item);
            }

            // Generate recent drivers
            recentDrivers = new ObservableCollection<DriverItem>
            {
                new DriverItem { FirstName = "Liam", Rating = 5.0, IsOnline = true },
                new DriverItem { FirstName = "Noah", Rating = 5.0, IsOnline = false },
                new DriverItem { FirstName = "Olivia", Rating = 5.0, IsOnline = true },
                new DriverItem { FirstName = "Emma", Rating = 5.0, IsOnline = true }
            };           

            // Generate recent activity (last 3 transactions)
            recentActivity = new ObservableCollection<WalletTransaction>();
            if (testTransactions.Count >= 3)
            {
                recentActivity.Add(testTransactions[0]);
                recentActivity.Add(testTransactions[1]);
                recentActivity.Add(testTransactions[2]);
            }

            // Generate active order
            activeOrder = new OrderItem
            {
                Id = "1234567890",
                RestaurantName = "The Daily Grind",
                ETA = "15 min",
                Status = "In transit",
                Driver = new DriverItem { FirstName = "Ethan" }
            };

            // Set saved address
            savedAddress = "123 Main St, Anytown, USA";
        }
        #endregion

        #region Tasks


        #endregion

    }


}
