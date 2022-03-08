using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class RoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }
        public List<Role> GetAllRole()
        {
            return roleRepository.GetAllRole();
        }
        public bool CreateRole(Role role)
        {
            return roleRepository.CreateRole();    
        }
        public bool UpdateRole(Role role)
        {
            return roleRepository.UpdateRole();
        }
        public bool DeleteRole(int Id)
        {
            return roleRepository.DeleteRole();
        }
    }
}
