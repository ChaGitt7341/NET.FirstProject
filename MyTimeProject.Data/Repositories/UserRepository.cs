using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Repoitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Data.Repositories
{
    public class UserRepository : Repository<User>, IPrsenceRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
        
    }
}
