﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
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
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public List<User> GetAllUser()
        {
            return _userService.GetAllUser();
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateUser([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }

        [HttpPut]
        [Route("Update")]

        public bool UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteUser(int id)
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
                var fullPath = Path.Combine("D:\\Training\\Tahaluf Training Center 2021\\Chapters\\Final Project\\BusTrackingAngular\\src\\assets\\images", fileName);
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
    }
}
