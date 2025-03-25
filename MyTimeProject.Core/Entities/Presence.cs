using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Entities
{
   
    public class Presence
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
       
        public virtual int UserId { get; set; }
        
        public DateOnly Date { get; set; }
        public TimeOnly TimeOfStart { get; set; }
        public TimeOnly TimeOfEnd { get; set; }
        public TypeOfTime Type { get; set; }
        public Approvals? Approval { get; set; }

        
        public Presence()
        {
        }

        public Presence(int userId, DateOnly date, TimeOnly timeOfStart)
        {

            UserId = userId;
            Date = date;
            TimeOfStart = timeOfStart;
        }

        public Presence(int userId, DateOnly date, TimeOnly timeOfStart, TimeOnly timeOfEnd, Approvals approval) : this(userId, date, timeOfStart)
        {
            TimeOfEnd = timeOfEnd;
            Approval=approval;
        }
    }
}
