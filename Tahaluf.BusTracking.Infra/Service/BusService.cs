using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class BusService : IBusService
    {
        private readonly IBusRepository busRepository;
        public BusService(IBusRepository _busRepository)
        {
            busRepository = _busRepository;
        }

        public List<Bu> GetAllBus()
        {
            return busRepository.GetAllBus();
        }
        public bool CreateBus(Bu bus)
        {
            return busRepository.CreateBus(bus);
        }
        public bool UpdateBus(Bu bus)
        {
            return busRepository.UpdateBus(bus);

        }
        public bool DeleteBus(int id)
        {
            return busRepository.DeleteBus(id);
        }

        public List<GetBusDriversDTO> GetBusDrivers()
        {

            return busRepository.GetBusDrivers();
        }

        public List<GetBusTeachersDTO> GetBusTeaachers()
        {
            return busRepository.GetBusTeaachers();
        }
        //public  Task<List<Bu>> GETSTUDENTLIST()
        //{
        //    return busRepository.GETSTUDENTLIST();
        //}

        public List<StudentDto> GETSTUDENTLIST(StudentDto student)
        {
            return busRepository.GETSTUDENTLIST(student);
        }


        public Bu GetBusInfoByUsername(string name)
        {
            return busRepository.GetBusInfoByUsername(name);
        }


        public List<Student> GetBusStudents(int busid)
        {

            return busRepository.GetBusStudents(busid);
        }

        public List<Route> GetRouteByBus(int busid) { 
        
            return busRepository.GetRouteByBus(busid);  
        }
    }
}