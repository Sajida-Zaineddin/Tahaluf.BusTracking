using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface ILoginRepository
    {
        LoginDTO Auth(Login login);


        bool CreateLoginUser(Login login );

        bool UpdateLoginUser(Login login);

        string DeleteLoginUser(int id);

        List<LoginWithFullNamesDTO> GetAllUsersWithNames();

         bool UpdateLoginUserPassword(Login login);


    }
}
