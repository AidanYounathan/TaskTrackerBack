using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskTrackerBackend.Models;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services;

namespace TaskTrackerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService data)
        {
            _data = data;
        }  

        [HttpPost]
        [Route("Login")]

        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }


        [HttpPost]
        [Route("CreateUser")]

        public bool CreateUser(CreateAccountDTO UserToAdd)
        {
            return _data.CreateUser(UserToAdd);
        }

        [HttpPut]
        [Route("UpdateUser")]

        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }
        
        [HttpPut]
        [Route("UpdateUsername/{id}/{username}")]
        public bool UpdateUsername(int id, string username)
        {
            return _data.UpdateUsername(id,username);
        }


        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]

        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public UserModel GetUserByUsername(string username)
        {
            return _data.GetUserByUsername(username);
        }

        [HttpPut]
        [Route("UpdateProfileImg/{id}/{profileImg}")]
        public bool UpdateProfileImg(int id, string profileImg)
        {
            return _data.UpdateProfileImg(id,profileImg);
        }



        [HttpGet]
        [Route("GenerateImgID")]
        public string GenerateImgID()
        {
            return _data.GenerateImgID();
        }

       
        



    }
}

// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Net;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using TaskTrackerBackend.Models;
// using TaskTrackerBackend.Models.DTO;
// using TaskTrackerBackend.Services;

// namespace TaskTrackerBackend.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class UserController : ControllerBase
//     {
//         private readonly UserService _data;

//         public UserController(UserService data)
//         {
//             _data = data;
//         }  

//         [HttpPost]
//         [Route("Login")]

//         public IActionResult Login([FromBody] LoginDTO User)
//         {
//             return _data.Login(User);
//         }


//         [HttpPost]
//         [Route("CreateUser")]

//         public bool CreateUser(CreateAccountDTO UserToAdd)
//         {
//             return _data.CreateUser(UserToAdd);
//         }

//         [HttpPut]
//         [Route("UpdateUser")]

//         public bool UpdateUser(UserModel userToUpdate)
//         {
//             return _data.UpdateUser(userToUpdate);
//         }
        
//         [HttpPut]
//         [Route("UpdateUsername/{id}/{username}")]
//         public bool UpdateUsername(int id, string username)
//         {
//             return _data.UpdateUsername(id,username);
//         }


//         [HttpDelete]
//         [Route("DeleteUser/{userToDelete}")]

//         public bool DeleteUser(string userToDelete)
//         {
//             return _data.DeleteUser(userToDelete);
//         }

//         [HttpGet]
//         [Route("GetUserByUsername/{username}")]
//         public UserModel GetUserByUsername(string username)
//         {
//             return _data.GetUserByUsername(username);
//         }

//         [HttpPut]
//         [Route("UpdateProfileImg/{id}/{profileImg}")]
//         public bool UpdateProfileImg(int id, string profileImg)
//         {
//             return _data.UpdateProfileImg(id,profileImg);
//         }



//         [HttpGet]
//         [Route("GenerateImgID")]
//         public string GenerateImgID()
//         {
//             return _data.GenerateImgID();
//         }

       
        



//     }
// }