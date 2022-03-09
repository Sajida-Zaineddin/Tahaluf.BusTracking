using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IUserService
    {
        List<User> GetAllUser();
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
