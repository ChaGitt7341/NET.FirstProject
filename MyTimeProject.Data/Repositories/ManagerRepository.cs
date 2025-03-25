using MyTimeProject.Core.Repoitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Data.Repositories
{
    public class ManagerRepository<T>: IManagerRepository<T> where T : class
    {
        private readonly DataContext _context;
        public IRepository<T> repository { get; }

        public ManagerRepository(DataContext context, IRepository<T> repository)
        {
            _context = context;
            this.repository = repository;
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
