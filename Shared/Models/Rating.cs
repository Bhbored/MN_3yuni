using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Helpers.Enums;

namespace Shared.Models
{
    public class Rating
    {
        public long Id { get; set; }
        public long Order_Id { get; set; }
        public long Rater_User_Id { get; set; }
        public long Ratee_User_Id { get; set; }
        public RatingContext Role_Context { get; set; }
        public short RatingValue { get; set; }
        public string? Review_Text { get; set; }
        public DateTime Created_At { get; set; }
    }
}
