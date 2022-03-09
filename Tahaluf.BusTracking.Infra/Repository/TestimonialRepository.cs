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
    public class TestimonialRepository : ITestimonialRepository
    {

        private readonly IDbContext DbContext;



        public TestimonialRepository(IDbContext _DbContext)
        {

            DbContext = _DbContext;
        }

        public List<Testimonial> GetAllTestimonials()
        {
            IEnumerable<Testimonial> result = DbContext.Connection.Query<Testimonial>("TESTIMONIAL_PACKAGE.GETALLTESTIMONIALS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("userName", testimonial.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("photo", testimonial.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("opinion", testimonial.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("testStatId", testimonial.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.CREATETESTIMONIAL", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            
            p.Add("testId", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userName", testimonial.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("photo", testimonial.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("opinion", testimonial.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("testStatId", testimonial.Statusid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.UPDATETESTIMONIAL", p, commandType: CommandType.StoredProcedure);

            return true;
        }
        public string DeleteTestimonial(int id)
        {

            var p = new DynamicParameters();
            p.Add("testId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.DELETETESTIMONIAL", p, commandType: CommandType.StoredProcedure);

            return "deleted successfuly";
        }

     
       
    }
}
