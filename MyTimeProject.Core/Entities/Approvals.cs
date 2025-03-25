using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.Entities
{
    public enum TypeOfTime
    {
        Presence,
        Disease,
        Vacation,
        egnancyHours
    }
    public enum Status
    {
         InProcessing,
        approved, 
        notApproved

    }
    public class Approvals
    {
        public int Id { get; set; }
        
        public Status StatusRequet { get; set; }
        public string FileName { get; set; } // שם הקובץ
        public string ContentType { get; set; } // סוג התוכן של הקובץ
        public byte[] FileData { get; set; } // נתוני הקובץ
    }
}
