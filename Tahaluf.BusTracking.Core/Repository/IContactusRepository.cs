using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Repository
{
    public interface IContactusRepository
    {
        List <Contactu> GetContactus();
        bool CreateContactus(Contactu contactu);
        bool UpdateContactus(Contactu contactu);
        string DeleteContactus(int id);
    }
}
