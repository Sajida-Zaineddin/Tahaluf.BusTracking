using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository websiteRepository;
        public WebsiteService(IWebsiteRepository _websiteRepository)
        {
            websiteRepository = _websiteRepository;
        }
        public List<Website> GetAllWebsite()
        {
            return websiteRepository.GetAllWebsite();
        }
        public bool CreateWebsite(Website website)
        {
            return websiteRepository.CreateWebsite(website);
        }
        public bool UpdateWebsite(Website website)
        {
            return websiteRepository.UpdateWebsite(website);
        }
        public bool DeleteWebsite(int Id)
        {
            return websiteRepository.DeleteWebsite(Id);
        }

       

       
    }
}
