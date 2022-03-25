using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<UserDTO>), StatusCodes.Status200OK)]
        public List<UserDTO> GetAllUser()
        {
            return _userService.GetAllUser();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateUser([FromBody] UserDTO user)
        {
            return _userService.CreateUser(user);
        }

        [HttpPut]
        [Route("Update")]

        public bool UpdateUser([FromBody] UserDTO user)
        {
            return _userService.UpdateUser(user);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public string DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }

        [HttpPost]
        [Route("UploadImage")]
        public User UploadImage()
        {
            try
            {
                // Image -----> Request ----> Form
                var file = Request.Form.Files[0];

                // file.FileName
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // create folder "Images" in Tahaluf.LMS.API
                var fullPath = Path.Combine("D:\\Training\\Tahaluf Training Center 2021\\Chapters\\Final Project\\BusTrackingAngular\\src\assets\\images", fileName);
                // FileStream
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // DataBase
                User user = new User();
                user.Imagepath = fileName;
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetRole")]
        public List<Role> GetRole()
        {
            return _userService.GetRole();
        }

        [HttpGet]
        [Route("GetAllDrivers")]
        public List<User> GetAllDrivers()
        {
            return _userService.GetAllDrivers();
        }

        [HttpGet]
        [Route("GetAllTeachers")]
        public List<User> GetAllTeachers() { 
        
        return _userService.GetAllTeachers();
        }
    }
}
