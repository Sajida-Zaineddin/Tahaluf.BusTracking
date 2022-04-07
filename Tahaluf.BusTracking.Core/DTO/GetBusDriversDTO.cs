using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.BusTracking.Core.DTO
{
    public class GetBusDriversDTO
    {
        public decimal? Busnumber { get; set; }
        public decimal? Busdriver { get; set; }
        public string FullName { get; set; }
    }
}
