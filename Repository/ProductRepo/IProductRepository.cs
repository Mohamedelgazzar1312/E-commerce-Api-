using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepo
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);

    }
}
