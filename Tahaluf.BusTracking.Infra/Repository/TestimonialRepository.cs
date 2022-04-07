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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext DbContext;
        public TestimonialRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<TestimoinealDTO> GetAllTestimonials()
        {
            IEnumerable<TestimoinealDTO> result = DbContext.Connection.Query<TestimoinealDTO>("gettestDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateTestimonial(TestimoinealDTO testimonial)
        {
            var p = new DynamicParameters();
            p.Add("userName", testimonial.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("photo", testimonial.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("opinion", testimonial.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("testStat", "onhold", dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("testcreate", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateTestimonial(TestimoinealUpdateDTO testimonial)
        {
            var p = new DynamicParameters();
            p.Add("testId", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("testStat", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("testcreateUpdate", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public string DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("testId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.DELETETESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            return "deleted successfuly";
        }
        public List<Testimonialstatus> GetTestimonialStatus()
        {
            IEnumerable<Testimonialstatus> result = DbContext.Connection.Query<Testimonialstatus>("TESTIMONIALSTATUS_PACKAGE.GETALLTESTIMONIALSTATUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
