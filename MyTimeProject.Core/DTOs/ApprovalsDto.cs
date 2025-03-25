using MyTimeProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeProject.Core.DTOs
{
    public class ApprovalsDto
    {
       
        public Status StatusRequet { get; set; }
        public string? FileName { get; set; } // שם הקובץ
        public string? ContentType { get; set; } // סוג התוכן של הקובץ
        public byte[]? FileData { get; set; }
    }
}
