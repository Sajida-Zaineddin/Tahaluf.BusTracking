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
    public class WebsitehomeRepository : IWebsitehomeRepository
    {
        private readonly IDbContext dbContext;
        public WebsitehomeRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Websitehome> GetAllwebsitehome()
        {
            IEnumerable<Websitehome> result = dbContext.Connection.Query<Websitehome>("WEBSITEHOME_PACKAGE.GETALLWEBSITEHOME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool Createwebsitehome(Websitehome websitehome)
        {
            var par = new DynamicParameters();
            par.Add("@IMG", websitehome.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HTITLE", websitehome.Titel, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HTEXT", websitehome.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HWEBSITEID", websitehome.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("WEBSITEHOME_PACKAGE.CREATEWEBSITEHOME", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Updatewebsitehome(Websitehome websitehome)
        {
            var par = new DynamicParameters();
            par.Add("@HOMEID", websitehome.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            par.Add("@IMG", websitehome.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HTITLE", websitehome.Titel, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HTEXT", websitehome.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            par.Add("@HWEBSITEID", websitehome.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("WEBSITEHOME_PACKAGE.UPDATEWEBSITEHOME", par, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Deletewebsitehome(int Id)
        {
            var par = new DynamicParameters();
            par.Add("@HOMEID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("WEBSITEHOME_PACKAGE.DELETEWEBSITEHOME", par, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
