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

        public List<LoginWithFullNamesDTO> GetAllUsersWithNames() {


            IEnumerable<LoginWithFullNamesDTO> result = DbContext.Connection.Query<LoginWithFullNamesDTO>("GETLOGINUSERSWITHNAMES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool CreateLoginUser(Login login) {

            var p = new DynamicParameters();
            p.Add("UNAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
      
            var result = DbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.CREATELOGIN", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateLoginUser(Login login) {

            var p = new DynamicParameters();
            p.Add("LOGIN_ID", login.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UNAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.UPDATELOGIN", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public string DeleteLoginUser(int id) {

            var p = new DynamicParameters();
            p.Add("LOGIN_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.DELETELOGIN", p, commandType: CommandType.StoredProcedure);

            return "deleted successfuly";
        }

    }
}
