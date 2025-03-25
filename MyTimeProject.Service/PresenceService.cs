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
    public class PresenceService : IPresenceService
    {

        private readonly IPresenceRepository _presenceRepository;
        private readonly IManagerRepository<Presence> _managerRepository;

        public PresenceService(IPresenceRepository presenceRepository, IManagerRepository<Presence> managerRepository)
        {
            _presenceRepository = presenceRepository;
            _managerRepository = managerRepository;
        }

        public async Task<Presence> AddAsync(Presence presence)
        {
            await _presenceRepository.PostAsync(presence);
            await _managerRepository.SaveAsync();
            return presence;
        }

        public async Task<List<Presence>> GetAllAsync()
        {
            return await _presenceRepository.GetAllAsync();

        }

        public async Task<List<Presence>> GetAllByDateAsync(DateOnly date)
        {
            return await _presenceRepository.GetAllPresencesByDateAsync(date);
        }

        public async Task<List<Presence>> GetAllByUserIdAsync(int userId)
        {
            return await _presenceRepository.GetAllPresencesByUserIdAsync(userId);
        }

        public Task<Presence>? GetByIdAsync(int id)
        {
            return _presenceRepository.GetByIdAsync(id);
        }

        public async Task Remove(int id)
        {
            var presence = await _presenceRepository.GetByIdAsync(id);
            if (presence != null) { _presenceRepository.Delete(presence); }
            await _managerRepository.SaveAsync();
        }

        public async Task Update(Presence presence)
        {
            _presenceRepository.Put(presence);
           await _managerRepository.SaveAsync();
        }
    }
}
