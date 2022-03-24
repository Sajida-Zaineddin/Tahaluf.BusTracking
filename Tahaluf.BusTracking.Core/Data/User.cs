using System;
using System.Collections.Generic;

#nullable disable

namespace Tahaluf.BusTracking.Core.Data
{
    public partial class User
    {
      
        public decimal Id { get; set; }
        public string FullName{ get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Imagepath { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Bu> BuBusdriverNavigations { get; set; }
        public virtual ICollection<Bu> BuBusteacherNavigations { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
