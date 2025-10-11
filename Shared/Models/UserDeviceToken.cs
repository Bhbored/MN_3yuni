using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class UserDeviceToken
    {
        public long Id { get; set; }

        public long UserId { get; set; }               // FK → Users.Id
        public string DeviceToken { get; set; } = null!;
        public string DeviceType { get; set; } = null!; // e.g., "android", "ios", "web"
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Nav
        public User? User { get; set; }
    }
}
