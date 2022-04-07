using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class RoleService : IRoleService
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
            return roleRepository.CreateRole(role);    
        }
        public bool UpdateRole(Role role)
        {
            return roleRepository.UpdateRole(role);
        }
        public bool DeleteRole(int Id)
        {
            return roleRepository.DeleteRole(Id);
        }
    }
}
