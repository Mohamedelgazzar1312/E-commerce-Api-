using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailsRepo

{
   public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
    }
}
