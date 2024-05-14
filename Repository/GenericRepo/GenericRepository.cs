using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
namespace Repository.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly E_Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(E_Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public  async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();

        }

        public  async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public  async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public  async Task UpdateAsync(T entity)
        {
           _dbSet.Update(entity);   
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(int id)
        {  
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }



}



