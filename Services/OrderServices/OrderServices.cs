using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.GenericRepo;
using Repository.OrderRepo;
using Services.GenericServices;
using Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderServices
{
    public class OrderService : GenericService<Order, OrderDTO>, IOrderService
    {
        public OrderService(IOrderRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

       

    }
}
