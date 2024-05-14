using Context;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailsRepo
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    
    {
         E_Context _cont;
        public OrderDetailsRepository(E_Context context) : base(context)
        {
            _cont = context;
        }
    }
}
