using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext DbContext;
        public UserRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<User> GetAllUser()
        {
            IEnumerable<User> result = DbContext.Connection.Query<User>("USERS_PACKAGE.GETALLUSERS", commandType: CommandType.StoredProcedure);
            return result.ToList();

          
        }

        public bool CreateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("FNAME", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LNAME", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NO", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_ID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.CREATEUSERS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("USERS_ID", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FNAME", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LNAME", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NO", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_ID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.UPDATEUSERS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("USERS_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.DELETEUSERS", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
