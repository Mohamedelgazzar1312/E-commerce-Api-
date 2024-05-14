using Dtos.DTOS;
using Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderServices
{
    public interface IOrderService : IGenericService<OrderDTO> { }
}
