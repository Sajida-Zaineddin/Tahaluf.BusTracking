using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IBusRepository
    {
        List<Bu> GetAllBus();
        bool CreateBus(Bu bus);
        bool UpdateBus(Bu bus);
        bool DeleteBus(int id);
        List<GetBusDriversDTO> GetBusDrivers(); 
        List<GetBusTeachersDTO> GetBusTeaachers();
        List<GetStudentListByTeacher> GETSTUDENTLIST(int busnumber);
        Bu GetBusInfoByUsername(string name);
        List<Student> GetBusStudents(int busid);
        List<Route> GetRouteByBus(int busid);
    }
}
