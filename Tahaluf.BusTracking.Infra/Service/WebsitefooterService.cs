using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class WebsitefooterService : IWebsitefooterService
    {
        private readonly IWebsitefooterRepository websitefooterRepository;

        public WebsitefooterService(IWebsitefooterRepository _websitefooterRepository)
        {
            websitefooterRepository = _websitefooterRepository;
        }
        public List<Websitefooter> GetAllwebsitefooter()
        {
            return websitefooterRepository.GetAllwebsitefooter();
        }
        public bool Createwebsitefooter(Websitefooter websitefooter)
        {
            return websitefooterRepository.Createwebsitefooter(websitefooter);    
        }
        public bool Updatewebsitefooter(Websitefooter websitefooter)
        {
            return websitefooterRepository.Updatewebsitefooter(websitefooter);
        }
        public bool Deletewebsitefooter(int Id)
        {
            return websitefooterRepository.Deletewebsitefooter(Id);
        }
    }
}
