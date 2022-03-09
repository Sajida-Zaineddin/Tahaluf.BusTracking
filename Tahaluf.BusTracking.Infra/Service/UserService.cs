using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
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

        public List<User> GetAllUser()
        {
            return userRepository.GetAllUser();
        }

        public bool CreateUser(User user)
        {
            return userRepository.CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            return userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }
    }
}
