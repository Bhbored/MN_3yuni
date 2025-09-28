using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class User
    {
        public long Id { get; set; }
        //public string Email { get; set; } = default!;
        //public string PasswordHash { get; set; } = default!;
        public string? Phone { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public UserRole User_Type { get; set; }
        public string? ProfileImageUrl { get; set; }
        public decimal? WalletBalance { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        //public Driver? Driver { get; set; }
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
