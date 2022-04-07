using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class GetStudentListByTeacher
    {
        public string Name { get; set; }
        public string roundStatus { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}