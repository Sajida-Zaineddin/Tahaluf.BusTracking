using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {

        private readonly IContactusService  contactusService;

        public ContactusController(IContactusService contactusService)
        {

            this.contactusService = contactusService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Contactu>), StatusCodes.Status200OK)]
        public List<Contactu> GetAllContactus()
        {
            return contactusService.GetContactus();

        }

        [HttpPost]
        [Route("CreateContactus")]
        public bool CreateContactus([FromBody] Contactu  contactu)
        {
            return contactusService.CreateContactus(contactu);
        }


        [HttpDelete]
        [Route("Delete/{id}")]

        public string DeleteContactus(int id)
        {
            return contactusService.DeleteContactus(id);
        }

        [HttpPut]
        [Route("UpdateContactus")]
        public bool UpdateContactus([FromBody] Contactu contactu)
        {
            return contactusService.UpdateContactus(contactu);
        }

    }
}
