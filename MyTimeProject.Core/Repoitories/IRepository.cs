using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Repoitories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T>? GetByIdAsync(int id);
        Task<T> PostAsync(T t);
        void Put( T t);
        void Delete(T? t);

    }
}
