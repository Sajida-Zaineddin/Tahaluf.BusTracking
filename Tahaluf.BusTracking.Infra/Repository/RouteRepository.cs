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
    public class RouteRepository : IRouteRepository
    {
        private readonly IDbContext DbContext;
        public RouteRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CREATEROUTE(RouteDTO route)
        {
            var p = new DynamicParameters();
            p.Add("X_START", route.Xstart, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_START", route.Ystart, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_CURRENT", route.Xcurrent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_CURRENT", route.Ycurrent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_END", route.Xend, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_END", route.Yend, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUM", route.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ROUTE_PACKAGE.CREATEROUTE", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string DELETEROUTE(int id)
        {
            var p = new DynamicParameters();
            p.Add("ROUTEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ROUTE_PACKAGE.DELETEROUTE", p, commandType: CommandType.StoredProcedure);
            return "Succesfully deleted";
        }

        public List<RouteDTO> GETALLROUTE()
        {
            IEnumerable<RouteDTO> result = DbContext.Connection.Query<RouteDTO>("ROUTE_PACKAGE.GETALLROUTE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UPDATEROUTE(RouteDTO route)
        {
            var p = new DynamicParameters();
            p.Add("ROUTEID", route.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("X_START", route.Xstart, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_START", route.Ystart, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_CURRENT", route.Xcurrent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_CURRENT", route.Ycurrent, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_END", route.Xend, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_END", route.Yend, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUM", route.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ROUTE_PACKAGE.UPDATEROUTE", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
