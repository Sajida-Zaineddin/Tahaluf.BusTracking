using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;
using Tahaluf.BusTracking.Infra.Repository;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository routeRepository;
        public RouteService(IRouteRepository _routeRepository)
        {
            routeRepository = _routeRepository;

        }

        public bool CREATEROUTE(Route route)
        {
            return routeRepository.CREATEROUTE(route);
        }

        public string DELETEROUTE(int id)
        {

            return routeRepository.DELETEROUTE(id);
        }

        public List<Route> GETALLROUTE()
        {

            return routeRepository.GETALLROUTE();
        }

        public bool UPDATEROUTE(Route route)
        {

            return routeRepository.UPDATEROUTE(route);
        }

        public Route SELECTFROMROUTEBYUSERNAME(string email)
        {

            return routeRepository.SELECTFROMROUTEBYUSERNAME(email);
        }
        public bool SETCURRENTBUSLOCATION(SetCurrentBusLocationDTO setCurrentBusLocationDTO)
        {

            return routeRepository.SETCURRENTBUSLOCATION(setCurrentBusLocationDTO);
        }
        public bool setCurrentBusLocationAfterEnd(SetCurrentBusLocationDTO setCurrentBusLocationDTO) {

            return routeRepository.setCurrentBusLocationAfterEnd(setCurrentBusLocationDTO);
        }
    }
}