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
    public class AboutusEditorRepository : IAboutusEditorRepository
    {
        private readonly IDbContext DbContext;
        public AboutusEditorRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CREATEABOUTUSEDITOR(Aboutuseditor aboutuseditor)
        {
            var p = new DynamicParameters();
            p.Add("IMG", aboutuseditor.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", aboutuseditor.Titel, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("INFO", aboutuseditor.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABID", aboutuseditor.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ABOUTUSEDITOR_PACKAGE.CREATEABOUTUSEDITOR", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string DELETEABOUTUSEDITOR(int id)
        {
            var p = new DynamicParameters();
            p.Add("AUEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ABOUTUSEDITOR_PACKAGE.DELETEABOUTUSEDITOR", p, commandType: CommandType.StoredProcedure);
            return "Succesfully deleted";
        }

        public List<Aboutuseditor> GETAABOUTUSEDITOR()
        {

            IEnumerable<Aboutuseditor> result = DbContext.Connection.Query<Aboutuseditor>("ABOUTUSEDITOR_PACKAGE.GETAABOUTUSEDITOR", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UPDATEABOUTUSEDITOR(Aboutuseditor aboutuseditor)
        {
            var p = new DynamicParameters();
            p.Add("AUEID", aboutuseditor.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMG", aboutuseditor.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", aboutuseditor.Titel, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("INFO", aboutuseditor.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ABID", aboutuseditor.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("ABOUTUSEDITOR_PACKAGE.UPDATEABOUTUSEDITOR", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
