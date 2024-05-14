using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.CartRepo;
using Repository.GenericRepo;
using Services.GenericServices;
using Services.OrderDetailsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CartServices
{
    public class CartService : GenericService<Cart,CartDTO>, ICartService
    {
        public CartService(IcartRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            
        }
    }
}
