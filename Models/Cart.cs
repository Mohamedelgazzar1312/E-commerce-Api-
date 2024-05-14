using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
