using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.GenericRepo;
using Repository.ProductRepo;
using Services.GenericServices;
using Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServices
{
   

    public class ProductService : GenericService<Product, ProductDTO>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
            : base(productRepository, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }




}
