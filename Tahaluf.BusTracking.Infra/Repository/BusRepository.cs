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
    public class BusRepository : IBusRepository
    {
        private readonly IDbContext DbContext;
        public BusRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public List<Bu> GetAllBus()
        {
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("BUS_PACKAGE.GETALLBUSES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateBus(Bu bus)
        {
            var p = new DynamicParameters();
            p.Add("BUS_NO", bus.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_DRIVER", bus.Busdriver, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_TEACHER", bus.Busteacher, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.CREATEBUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateBus(Bu bus)
        {
            var p = new DynamicParameters();
            p.Add("BUS_ID", bus.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_NO", bus.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_DRIVER", bus.Busdriver, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_TEACHER", bus.Busteacher, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.UPDATEBUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteBus(int id)
        {
            var p = new DynamicParameters();
            p.Add("BUS_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.DELETEBUS", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
