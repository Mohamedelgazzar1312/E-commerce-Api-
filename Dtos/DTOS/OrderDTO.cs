using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DTOS
{

    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        [DefaultValue("NotShipped")]
        public string Status { get; set; } 

    }

}
