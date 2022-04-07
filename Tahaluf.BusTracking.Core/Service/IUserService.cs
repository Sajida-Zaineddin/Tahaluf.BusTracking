using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IUserService
    {
        List<UserDTO> GetAllUser();
        bool CreateUser(UserDTO user);
        bool UpdateUser(UserDTO user);
        string DeleteUser(int id);
        List<Role> GetRole();
        List<User> GetAllDrivers();
        List<User> GetAllTeachers();
        User GteUserByUusernameFroEdit(Login login);
        bool UpdateUserNormal(User user);
        List<User> GETTEACHERINFO(string Uname);
        List<teacherBusList> GETTEACHERID(string Uname);
    }
}
