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
    public class WebsitefooterRepository : IWebsitefooterRepository
    {
        private readonly IDbContext dbContext;
        public WebsitefooterRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Websitefooter> GetAllwebsitefooter()
        {
            IEnumerable<Websitefooter> result = dbContext.Connection.Query<Websitefooter>("WEBSITEFOOTER_PACKAGE.GETALLWEBSITEFOOTER", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool Createwebsitefooter(Websitefooter websitefooter)
        {
            var par = new DynamicParameters();
            par.Add("@FTEXT", websitefooter.Abouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FCITY", websitefooter.City, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FPHONE", websitefooter.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FEMAIL", websitefooter.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FWEBSITEID", websitefooter.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITEFOOTER_PACKAGE.CREATEWEBSITEFOOTER", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Updatewebsitefooter(Websitefooter websitefooter)
        {
            var par = new DynamicParameters();
            par.Add("@FOOTERID", websitefooter.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@FTEXT", websitefooter.Abouttext, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FCITY", websitefooter.City, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FPHONE", websitefooter.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FEMAIL", websitefooter.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@FWEBSITEID", websitefooter.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITEFOOTER_PACKAGE.UPDATEWEBSITEFOOTER", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Deletewebsitefooter(int Id)
        {
            var par = new DynamicParameters(); 
            par.Add("@FOOTERID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITEFOOTER_PACKAGE.DELETEWEBSITEFOOTER", par, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
