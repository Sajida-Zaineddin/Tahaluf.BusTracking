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
    public class AboutusRepository : IAboutusRepository
    {
        private readonly IDbContext DbContext;
        public AboutusRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public List<Aboutu> GetAboutus()
        {
            IEnumerable<Aboutu> result = DbContext.Connection.Query<Aboutu>("ABOUTUS_PACKAGE.GETABOUTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateAboutus(Aboutu aboutu)
        {
            var p = new DynamicParameters();
            p.Add("IMG", aboutu.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", aboutu.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("INFO", aboutu.Information, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ABOUTUS_PACKAGE.CREATEABOUTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateAboutus(Aboutu aboutu)
        {
            var p = new DynamicParameters();
            p.Add("AUID", aboutu.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMG", aboutu.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", aboutu.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("INFO", aboutu.Information, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ABOUTUS_PACKAGE.UPDATEABOUTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public string DeleteAboutus(int id)
        {
            var p = new DynamicParameters();
            p.Add("AUID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("ABOUTUS_PACKAGE.DELETEABOUTUS", p, commandType: CommandType.StoredProcedure);
            return "deleted successfuly";
        }
        public Aboutu GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Aboutu> result = DbContext.Connection.Query<Aboutu>("GetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
