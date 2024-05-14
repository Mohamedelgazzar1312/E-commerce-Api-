using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.GenericRepo;
using Repository.OrderDetailsRepo;
using Services.GenericServices;
using Services.OrderServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderDetailsServices
{
    public class OrderDetailService : GenericService<OrderDetail, OrderDetailDTO>, IOrderDetailService
    {
        public OrderDetailService(IOrderDetailsRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
