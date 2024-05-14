using Dtos.DTOS;
using Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServices
{
    public interface IProductService : IGenericService<ProductDTO> {

        Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);


    }

}
