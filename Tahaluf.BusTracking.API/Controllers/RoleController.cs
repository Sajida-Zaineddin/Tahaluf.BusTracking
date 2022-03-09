using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAllRole()
        {
            return roleService.GetAllRole();
        }


        [HttpPost]
        [Route("CreateRole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool CreateRole(Role role)
        {
            return roleService.CreateRole(role);
        }


        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool UpdateRole([FromBody] Role role)
        {
            return roleService.UpdateRole(role);
        }


        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status400BadRequest)]
        public bool DeleteRole([FromBody] int Id)
        {
            return roleService.DeleteRole(Id);
        }


    }
}
