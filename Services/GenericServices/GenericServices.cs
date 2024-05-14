using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepo;
namespace Services.GenericServices
{
    public  class GenericService<TModel, TDTO> : IGenericService<TDTO>
        where TModel : class
        where TDTO : class
    {
        protected readonly IGenericRepository<TModel> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task<List<TDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<TDTO>>(entities);
        }

        public async Task<TDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
         
            return _mapper.Map<TDTO>(entity);
        }

        public async Task<TDTO> CreateAsync(TDTO dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            entity = await _repository.CreateAsync(entity);
            return _mapper.Map<TDTO>(entity);
        }

        public async Task UpdateAsync(TDTO dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
