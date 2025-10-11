using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace MN_3yuni_MAUI.TestData
{
    public class WalletTransactionTestDataGenerator
    {
        private readonly Faker<WalletTransaction> _transactionFaker;

        public WalletTransactionTestDataGenerator()
        {
            _transactionFaker = new Faker<WalletTransaction>()
                .RuleFor(t => t.Id, f => f.IndexFaker + 1)
                .RuleFor(t => t.Transaction_Type, f => f.PickRandom<WalletTxType>())
                .RuleFor(t => t.Amount, f => f.Finance.Amount(1, 500, 2))
                .RuleFor(t => t.Currency, "USD")
                .RuleFor(t => t.Status, f => f.PickRandom<WalletTxStatus>())
                .RuleFor(t => t.Created_At, f => f.Date.Recent(30));
        }

        public WalletTransaction GenerateSingle()
        {
            return _transactionFaker.Generate();
        }

        public List<WalletTransaction> Generate(int count)
        {
            return _transactionFaker.Generate(count);
        }

        public WalletTransaction GenerateSingle(Action<WalletTransaction, Faker> configure)
        {
            return _transactionFaker.CustomInstantiator(f => GenerateWithCustomConfig(f))
                           .FinishWith((f, t) => configure(t, f))
                           .Generate();
        }

        private WalletTransaction GenerateWithCustomConfig(Faker f)
        {
            return _transactionFaker.Generate();
        }

        public List<WalletTransaction> GenerateWithCriteria(
            int count,
            WalletTxType? transactionType = null,
            WalletTxStatus? status = null,
            decimal minAmount = 1,
            decimal maxAmount = 500)
        {
            var faker = new Faker<WalletTransaction>()
                .RuleFor(t => t.Id, f => f.IndexFaker + 1)
                .RuleFor(t => t.Transaction_Type, f => transactionType ?? f.PickRandom<WalletTxType>())
                .RuleFor(t => t.Amount, f => f.Finance.Amount(minAmount, maxAmount, 2))
                .RuleFor(t => t.Currency, "USD")
                .RuleFor(t => t.Status, f => status ?? f.PickRandom<WalletTxStatus>())
                .RuleFor(t => t.Created_At, f => f.Date.Recent(30));

            return faker.Generate(count);
        }

        public List<WalletTransaction> GenerateDeposits(int count)
        {
            return GenerateWithCriteria(count, WalletTxType.Deposit);
        }

        public List<WalletTransaction> GeneratePayments(int count)
        {
            return GenerateWithCriteria(count, WalletTxType.Payment);
        }

        public List<WalletTransaction> GenerateWithStatus(int count, WalletTxStatus status)
        {
            return GenerateWithCriteria(count, status: status);
        }
    }
}
