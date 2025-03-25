using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User>? GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task<User> RemoveAsync(int id);
        Task<User> AddAsync(User user);
    }
}
