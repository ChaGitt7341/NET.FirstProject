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
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T>? GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
              
        }
        public  async Task<T> PostAsync(T t)
        {
            await _dbSet.AddAsync(t);
            return t;
        }
        public void Put(T t)
        {
           
             _dbSet.Update(t);
            
        }
        public void Delete(T? t)
        {
            if (t != null) {_dbSet.Remove(t); }
         
        }
    }
}
