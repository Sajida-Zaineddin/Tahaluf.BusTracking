using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {

        private readonly IDbContext DbContext;


        public LoginRepository(IDbContext _DbContext)
        {

            DbContext = _DbContext;
        }
       public LoginDTO Auth(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@UNAME ", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<LoginDTO> result = DbContext.Connection.Query<LoginDTO>("USERLOGINAPI", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
