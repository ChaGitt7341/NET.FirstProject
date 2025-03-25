using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Services
{
    public interface IApprovalsService
    {
        Task<List<Approvals>> GetAllAsync();
        Task<Approvals>? GetByIdAsync(int id);
        Task UpdateAsync(Approvals approval);
        Task<Approvals> RemoveAsync(int id);
        Task<Approvals> AddAsync(Approvals approval);
    }
}
