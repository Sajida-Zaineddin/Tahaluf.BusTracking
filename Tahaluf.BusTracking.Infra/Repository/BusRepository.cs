using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
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

        public List<GetBusDriversDTO> GetBusDrivers()
        {

            IEnumerable<GetBusDriversDTO> result = DbContext.Connection.Query<GetBusDriversDTO>("getBusDrivers", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public List<GetBusTeachersDTO> GetBusTeaachers()
        {
            IEnumerable<GetBusTeachersDTO> result = DbContext.Connection.Query<GetBusTeachersDTO>("getBusTeachers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


            public List<StudentDto> GETSTUDENTLIST(StudentDto student)
            {
                var p = new DynamicParameters();
                p.Add("@BUS_NUMBER", student.busnumber, dbType: DbType.Int32);
                p.Add("@R_STATUS", student.Status, dbType: DbType.String);
    
                IEnumerable<StudentDto> result = DbContext.Connection.Query<StudentDto>("BUS_PACKAGE.GETSTUDENTLIST", p, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }

        public Bu GetBusInfoByUsername(string name)
        {
            var p = new DynamicParameters();
            p.Add("DRIVERNAME", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("GETBUSINFOBYUSERNAME", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Student> GetBusStudents(int busid)
        {
            var p = new DynamicParameters();
            p.Add("busnum", busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = DbContext.Connection.Query<Student>("getstudentsbusbybusid", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Route> GetRouteByBus(int busid)
        {
            var p = new DynamicParameters();
            p.Add("busnum", busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Route> result = DbContext.Connection.Query<Route>("GETROUTESBYBUSID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }

      
    }


