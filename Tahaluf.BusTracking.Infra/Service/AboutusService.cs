using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class AboutusService : IAboutusService
    {


        private readonly IAboutusRepository  aboutusRepository;
        public AboutusService(IAboutusRepository aboutusRepository)
        {
            this.aboutusRepository = aboutusRepository;
        }

        public List<Aboutu> GetAboutus()
        {
            return aboutusRepository.GetAboutus();
        }

        public bool CreateAboutus(Aboutu aboutu)
        {
            return aboutusRepository.CreateAboutus(aboutu);
        }


        public bool UpdateAboutus(Aboutu aboutu)
        {
           return aboutusRepository.UpdateAboutus(aboutu);
        }
        public string DeleteAboutus(int id)
        {
            
            return aboutusRepository.DeleteAboutus(id);
        }

        public Aboutu GetById(int id) {

            return aboutusRepository.GetById(id);
        }
    }
}
