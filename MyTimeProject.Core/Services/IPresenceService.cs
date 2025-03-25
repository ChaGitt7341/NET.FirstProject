using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Services
{
    public interface IPresenceService
    {
        Task<List<Presence>> GetAllAsync();
        Task<Presence>? GetByIdAsync(int id);
        Task<List<Presence>> GetAllByUserIdAsync(int id);
        Task<List<Presence>> GetAllByDateAsync(DateOnly date);

        Task Update(Presence presence);
        Task Remove(int id);
        Task<Presence> AddAsync(Presence presence);
    }
}
