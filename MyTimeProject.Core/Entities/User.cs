using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace MyTimeProject.Core.Entities
{
    public enum Roles
    {
        manager, worker
    }
    public class User
        
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

          
        public virtual ICollection<Presence> ListPresences { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User(int id, string name, string password, string email, Roles role) : this(id, name)
        {
            
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            
            Email = email;

            Role = role;
            
        }
    }
}
