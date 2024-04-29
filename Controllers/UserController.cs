using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using day2blogbackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;

namespace TaskTrackerBackend.Controllers;

     [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase

    {
        private readonly UserService _data;

        public UserController(UserService data){
            _data = data;
        }
        
        // Login Endpoint
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User){
            return _data.Login(User);
        }

        // AddUser Endpoint
            // if user already exists
            // if user does not exist, create new account
            // else return false

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd){
            return _data.AddUser(UserToAdd);
        }

        // UpdateUser Endpoint
        [HttpPut]
        [Route("UpdateUser")]
        
        public bool UpdateUser(UserModel userToUpdate){
            return _data.UpdateUser(userToUpdate);
        }

        [HttpPut]
        [Route("UpdateUser/{id}/{username}")]

        public bool UpdateUser(int id, string username){
            return _data.UpdateUsername(id, username);
        }

        // DeleteUser Endpoint
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }

        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public UserIdDTO GetUserByUsername(string username){
            return _data.GetUserIdDTOByUsername(username);
        }

    }
