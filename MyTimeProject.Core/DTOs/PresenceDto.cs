using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.DTOs
{
    public class PresenceDto
    {
        public Guid Id { get; set; }
        public int UserId  { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeOfStart { get; set; }
        public TimeOnly TimeOfEnd { get; set; }
        public TypeOfTime Type { get; set; }

        public Approvals? ApprovalDto { get; set; }
    }
}
