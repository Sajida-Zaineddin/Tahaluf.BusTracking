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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dbContext;
        public RoleRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GETALLROLE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateRole(Role role)
        {
            var par = new DynamicParameters();
            par.Add("@RNAME", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ROLE_PACKAGE.CREATEROLE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateRole(Role role)
        {
            var par = new DynamicParameters();
            par.Add("@ROLEID", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@RNAME", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ROLE_PACKAGE.UPDATEROLE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteRole(int Id)
        {
            var par = new DynamicParameters();
            par.Add("@ROLEID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ROLE_PACKAGE.DELETEROLE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
