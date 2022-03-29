using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IBusService
    {
        List<Bu> GetAllBus();
        bool CreateBus(Bu bus);
        bool UpdateBus(Bu bus);
        bool DeleteBus(int id);
        List<GetBusDriversDTO> GetBusDrivers();
        List<GetBusTeachersDTO> GetBusTeaachers();
        //Task<List<Bu>> GETSTUDENTLIST();
        List<StudentDto> GETSTUDENTLIST(StudentDto student);

        Bu GetBusInfoByUsername(string name);


        List<Student> GetBusStudents(int busid);

        List<Route> GetRouteByBus(int busid);
    }
}
