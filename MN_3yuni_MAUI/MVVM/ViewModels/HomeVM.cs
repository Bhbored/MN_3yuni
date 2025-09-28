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
    public partial class HomeVM : ObservableObject
    {
        [ObservableProperty]
        private User user;

        [ObservableProperty]
        private List<WalletTransaction> _transactions;

        public HomeVM()
        {
            generateTestDate();
        }
        public void generateTestDate()
        {
            user = new User
            {
                FirstName = "Ethan",
                WalletBalance = (decimal?)125.50
            };
            var generator = new WalletTransactionTestDataGenerator();
            var testTransactions = generator.Generate(50);//here add dummy transactions
            _transactions = new List<WalletTransaction>();
            foreach (var item in testTransactions)
            {
                Transactions.Add(item);
            }
        }

    }


}
