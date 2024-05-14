using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GenericServices
{
    public interface IGenericService<TDTO>
        where TDTO : class
    {
        Task<List<TDTO>> GetAllAsync();   
        Task<TDTO> GetByIdAsync(int id);
        Task<TDTO> CreateAsync(TDTO dto);
        Task UpdateAsync(TDTO dto);
        Task DeleteAsync(int id);
    }
}
