using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.GenericRepo;
using Repository.UserRepo;
using Services.GenericServices;
using Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CategoryServices
{
    public class CategoryService : GenericService<Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
