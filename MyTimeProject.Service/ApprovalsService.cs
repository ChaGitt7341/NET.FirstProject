using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Repoitories;
using MyTimeProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Service
{
    public class ApprovalsService : IApprovalsService
    {
        private readonly IRepository<Approvals> _repository;
        private readonly IManagerRepository<Approvals> _managerRepository;

        public ApprovalsService(IRepository<Approvals> repository, IManagerRepository<Approvals> managerRepository)
        {
            _repository = repository;
            _managerRepository = managerRepository;
        }

        public async Task<List<Approvals>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Approvals>? GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(Approvals approval)
        {
            _repository.Put(approval);
            await _managerRepository.SaveAsync();
        }
        public async Task<Approvals> RemoveAsync(int id)
        {
            var approval = await _repository.GetByIdAsync(id);
            if (approval != null)
            {
                _repository.Delete(approval);
                await _managerRepository.SaveAsync();
            }
            return approval;
        }
        public async Task<Approvals> AddAsync(Approvals approval)
        {
            await _repository.PostAsync(approval);
            await _managerRepository.SaveAsync();
            return approval;
        }
    }
}
