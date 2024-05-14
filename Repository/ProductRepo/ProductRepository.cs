using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepo
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        E_Context _cont;
        public ProductRepository(E_Context context) : base(context)
        {
            _cont = context;    
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _cont.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }


    }
}
