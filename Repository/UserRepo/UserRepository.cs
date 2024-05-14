using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepo  
{
    public class UserRepository : IUserRepository
    {
        private readonly E_Context _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(E_Context context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<User> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> CreateAsync(User entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(User entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
