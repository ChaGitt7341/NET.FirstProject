using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Repoitories
{
    public interface IPresenceRepository:IRepository<Presence>
    {
       Task< List<Presence>> GetAllPresencesByUserIdAsync(int userId);
        Task<List<Presence>> GetAllPresencesByDateAsync(DateOnly date);
    }
}
