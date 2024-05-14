using Context;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CartRepo
{
    public class CartRepository : GenericRepository<Cart>, IcartRepository
    {
        E_Context _cont;
        public CartRepository(E_Context context) : base(context)
        {
            _cont = context;
        }
    }
}
