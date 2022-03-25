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
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext DbContext;
        public UserRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<UserDTO> GetAllUser()
        {
            IEnumerable<UserDTO> result = DbContext.Connection.Query<UserDTO>("USERS_PACKAGE.GETUSERSDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateUser(UserDTO user)
        {
            var p = new DynamicParameters();
            p.Add("FULL_NAME", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NO", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_NAME", user.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.CREATEUSERS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateUser(UserDTO user)
        {
            var p = new DynamicParameters();
            p.Add("USERS_ID", user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FULL_NAME", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE_NO", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMG", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_NAME", user.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.UPDATEUSERS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("USERS_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("USERS_PACKAGE.DELETEUSERS", p, commandType: CommandType.StoredProcedure);

            return "deleted successfuly";
        }

        public List<Role> GetRole()
        {
            IEnumerable<Role> result = DbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> GetAllDrivers() {

            IEnumerable<User> result = DbContext.Connection.Query<User>("GETALLDRIVERS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> GetAllTeachers()
        {
            IEnumerable<User> result = DbContext.Connection.Query<User>("getallTeachers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
