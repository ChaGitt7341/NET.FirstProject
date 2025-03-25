using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Repoitories;
using MyTimeProject.Core.Services;
using MyTimeProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Service
{
    public class UserService: IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IManagerRepository<User> _managerRepository;

        public UserService(IRepository<User> repository, IManagerRepository<User> managerRepository)
        {
            _repository = repository;
            _managerRepository = managerRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<User>? GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(User user)
        {
            _repository.Put(user);
           await _managerRepository.SaveAsync();
        }
        public async Task<User> RemoveAsync(int id)
        {
            var user =await _repository.GetByIdAsync(id);
            if (user != null)
            {
                _repository.Delete(user);
               await _managerRepository.SaveAsync();
            }
            return user;
        }
        public async Task<User> AddAsync(User user)
        {
           await _repository.PostAsync(user);
           await _managerRepository.SaveAsync();
            return user;
        }
    }
}
