using Context;
using Models;
using Repository.GenericRepo;
using Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CategoryRepo
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        E_Context _cont;
        public CategoryRepository(E_Context context) : base(context)
        {
            _cont = context;
        }
    }
}
