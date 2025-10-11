using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MN_3yuni_MAUI.TestData
{
    public class UserTestDataGenerator
    {
        private readonly Faker<User> _userFaker;


        public UserTestDataGenerator()
        {
            _userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.ProfileImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(u => u.WalletBalance, f => f.Finance.Amount(0, 10000, 2))
                .RuleFor(u => u.Created_At, f => f.Date.Past(2, DateTime.Now.AddDays(-30)))
                .RuleFor(u => u.Updated_At, f => f.Date.Recent(30));
        }

        public User GenerateSingle()
        {
            return _userFaker.Generate();
        }

        public List<User> Generate(int count)
        {
            return _userFaker.Generate(count);
        }

        public User GenerateSingle(Action<User, Faker> configure)
        {
            return _userFaker.CustomInstantiator(f => GenerateWithCustomConfig(f))
                           .FinishWith((f, u) => configure(u, f))
                           .Generate();
        }

        private User GenerateWithCustomConfig(Faker f)
        {
            return _userFaker.Generate();
        }

        public List<User> GenerateWithCriteria(
            int count,
            decimal minBalance = 0,
            decimal maxBalance = 10000)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.ProfileImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(u => u.WalletBalance, f => f.Finance.Amount(minBalance, maxBalance, 2))
                .RuleFor(u => u.Created_At, f => f.Date.Past(2, DateTime.Now.AddDays(-30)))
                .RuleFor(u => u.Updated_At, f => f.Date.Recent(30));

            return faker.Generate(count);
        }

        public List<User> GenerateWithHighBalance(int count)
        {
            return new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("(###) ###-####"))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.ProfileImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(u => u.WalletBalance, f => f.Finance.Amount(5000, 50000, 2))
                .RuleFor(u => u.Created_At, f => f.Date.Past(2, DateTime.Now.AddDays(-30)))
                .RuleFor(u => u.Updated_At, f => f.Date.Recent(30))
                .Generate(count);
        }

        public List<User> GenerateWithZeroBalance(int count)
        {
            var users = Generate(count);
            foreach (var user in users)
            {
                user.WalletBalance = 0;
            }
            return users;
        }

    }
}
