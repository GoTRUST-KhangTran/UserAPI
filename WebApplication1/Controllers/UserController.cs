using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static List<User> users = new List<User>();
        [HttpGet("GetUsers")]

        public IEnumerable<User> GetAllUsers()
        {
            //users.Add(new User("tk", "khang", 21, "32dsss"));
            return users;
        }
        [HttpGet("GetUserName")]
        public User GetUserName(string UserName)
        {
            foreach (var user in users)
            {
                if (user.UserName == UserName)
                {
                    return user;
                }
            }
            return null;
        }
        [HttpPost("InputUser")]
        public IActionResult InputUser(User newUser)
        {
            if(newUser.UserName != null)
            {
                foreach (var user in users)
                {
                    if (newUser.UserName == user.UserName)
                    {
                        return BadRequest("Already have this user");
                    }
                }
                users.Add(newUser);
                return Ok("Add success");
            }
            return BadRequest("Input is empty");
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(string userName, User updateuser)
        {
            foreach (var user in users)
            {
                if (userName == user.UserName)
                {
                    user.Age = updateuser.Age;
                    user.Address = updateuser.Address;
                    return Ok("Success");
                }
            }
            return BadRequest("Cannot find user");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(string userName)
        {
            foreach(var user in users)
            {
                if(userName == user.UserName)
                {
                    users.Remove(user);
                    return Ok("Complete Delete!");
                }    
            }
            return BadRequest("Cannot find user!");
        }
    }
}
