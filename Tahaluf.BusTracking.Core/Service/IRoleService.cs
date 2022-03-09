using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IRoleService
    {
        List<Role> GetAllRole();
        bool CreateRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(int Id);
    }
}
