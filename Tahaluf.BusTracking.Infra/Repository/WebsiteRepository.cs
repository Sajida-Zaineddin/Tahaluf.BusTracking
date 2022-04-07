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
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly IDbContext dbContext;
        public WebsiteRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Website> GetAllWebsite()
        {
            IEnumerable<Website> result = dbContext.Connection.Query<Website>("WEBSITE_PACKAGE.GETALLWEBSITE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateWebsite(Website website)
        {
            var par = new DynamicParameters();
            par.Add("@SITENAME", website.Websitename, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@SITELOGO", website.Websitelogo, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@CONTACTID", website.Contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@ABOUTID", website.Aboutusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITE_PACKAGE.CREATEWEBSITE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateWebsite(Website website)
        {
            var par = new DynamicParameters();
            par.Add("@SITEID", website.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@SITENAME", website.Websitename, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@SITELOGO", website.Websitelogo, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@CONTACTID", website.Contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@ABOUTID", website.Aboutusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITE_PACKAGE.UPDATEWEBSITE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteWebsite(int Id)
        {
            var par = new DynamicParameters();
            par.Add("@SITEID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITE_PACKAGE.DELETEWEBSITE", par, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
