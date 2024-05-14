using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        E_Context _cont;
        public OrderRepository(E_Context context) : base(context)
        {
            _cont = context;
        }

        //public async Task UpdateAsync(string status)
        //{
        //    var order = await _cont.Orders.FindAsync(orderId);
        //    if (order != null)
        //    {
        //        order.Status = status;
        //        await _cont.SaveChangesAsync();
        //    }
        //}


    }
}
