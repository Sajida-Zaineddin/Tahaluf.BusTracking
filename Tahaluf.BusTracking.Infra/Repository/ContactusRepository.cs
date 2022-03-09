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
    public class ContactusRepository : IContactusRepository
    {

        private readonly IDbContext DbContext;



        public ContactusRepository(IDbContext _DbContext)
        {

            DbContext = _DbContext;
        }

        public List<Contactu> GetContactus()
        {
            IEnumerable<Contactu> result = DbContext.Connection.Query<Contactu>("CONTACTUS_PACKAGE.GETALLCONTACTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateContactus(Contactu contactu)
        {
            var p = new DynamicParameters();
            p.Add("FNAME", contactu.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LNAME", contactu.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", contactu.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTEXTMESSAGE", contactu.Massage, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("CONTACTUS_PACKAGE.CreateContactus", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateContactus(Contactu contactu)
        {
            var p = new DynamicParameters();
            p.Add("CONID", contactu.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FNAME", contactu.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LNAME", contactu.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MAIL", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("TXT", contactu.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTEXTMESSAGE", contactu.Massage, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("CONTACTUS_PACKAGE.UpdateContactus", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public string DeleteContactus(int id)
        {
            var p = new DynamicParameters();
            p.Add("CONID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("CONTACTUS_PACKAGE.DeleteContactus", p, commandType: CommandType.StoredProcedure);

            return "deleted successfuly";
        }

      

   
    }
}
