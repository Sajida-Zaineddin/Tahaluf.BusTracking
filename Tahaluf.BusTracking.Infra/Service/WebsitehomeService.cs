using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class WebsitehomeService : IWebsitehomeService
    {
        private readonly IWebsitehomeRepository websitehomeRepository;
        public WebsitehomeService(IWebsitehomeRepository _websitehomeRepository)
        {
            websitehomeRepository = _websitehomeRepository;
        }
        public List<Websitehome> GetAllwebsitehome()
        {
            return websitehomeRepository.GetAllwebsitehome();
        }
        public bool Createwebsitehome(Websitehome websitehome)
        {
            return websitehomeRepository.Createwebsitehome(websitehome);
        }
        public bool Updatewebsitehome(Websitehome websitehome)
        {
            return websitehomeRepository.Updatewebsitehome(websitehome);
        }
        public bool Deletewebsitehome(int Id)
        {
            return websitehomeRepository.Deletewebsitehome(Id);
        }
    }
}
