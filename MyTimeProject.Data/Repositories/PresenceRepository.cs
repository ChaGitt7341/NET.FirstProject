using Microsoft.EntityFrameworkCore;
using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Repoitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Data.Repositories
{
    public class PresenceRepository:Repository<Presence>, IPresenceRepository
    {
        public PresenceRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Presence>> GetAllPresencesByDateAsync(DateOnly date)
        {
            //return  _dbSet.Where<Presence>(p => p.Date.CompareTo(date)==0).ToList();
            return await _dbSet.Where(presence => presence.Date == date).ToListAsync();
        }

        public async Task<List<Presence>> GetAllPresencesByUserIdAsync(int id)
        {
            return await _dbSet.Where(p => p.UserId == id).ToListAsync();
           
        }

    }
}
