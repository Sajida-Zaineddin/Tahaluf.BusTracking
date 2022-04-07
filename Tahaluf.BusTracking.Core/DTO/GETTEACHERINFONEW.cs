using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class GETTEACHERINFONEW
    {
        public decimal? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal? busid { get; set; }
        public string Name { get; set; }
    }
}