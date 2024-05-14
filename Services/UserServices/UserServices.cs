using AutoMapper;
using Dtos.DTOS;
using Models;
using Repository.GenericRepo;
using Repository.UserRepo;
using Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(entities);
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(entity);
        }
        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            var user = await _repository.GetByUsernameAsync(username);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateAsync(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto); // Assuming UserDTO is mapped from User
            entity = await _repository.CreateAsync(entity);
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task UpdateAsync(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto); // Assuming UserDTO is mapped from User
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

