using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class ContactusService : IContactusService
    {
        private readonly IContactusRepository contactusRepository;
        public ContactusService(IContactusRepository contactusRepository)
        {
            this.contactusRepository = contactusRepository;
        }
        public List<Contactu> GetContactus()
        {
            return contactusRepository.GetContactus();
        }
        public bool CreateContactus(Contactu contactu)
        {
            return contactusRepository.CreateContactus(contactu);
        }
        public bool UpdateContactus(Contactu contactu)
        {
            return contactusRepository.UpdateContactus(contactu);
        }
        public string DeleteContactus(int id)
        {
            return contactusRepository.DeleteContactus(id);
        }
    }
}
