using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Tahaluf.BusTracking.Core.Common
{
  public  interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
