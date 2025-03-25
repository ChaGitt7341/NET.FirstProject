using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Repoitories
{
    public interface IManagerRepository<T> where T : class
    {
        Task SaveAsync();
    }
}
