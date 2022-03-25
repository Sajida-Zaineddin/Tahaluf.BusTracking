using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public List<UserDTO> GetAllUser()
        {
            return userRepository.GetAllUser();
        }

        public bool CreateUser(UserDTO user)
        {
            return userRepository.CreateUser(user);
        }

        public bool UpdateUser(UserDTO user)
        {
            return userRepository.UpdateUser(user);
        }

        public string DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }

        public List<Role> GetRole()
        {
            return userRepository.GetRole();
        }

        public List<User> GetAllDrivers()
        {
            return userRepository.GetAllDrivers();
        }

        public List<User> GetAllTeachers() { 
        
            return userRepository.GetAllTeachers();
        }
    }
}