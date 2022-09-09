using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>();
        [HttpGet]

        public IEnumerable<User> GetAllUsers()
        {
            //users.Add(new User("tk", "khang", 21, "32dsss"));
            return users;
        }
        [HttpGet("{UserName}")]
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
        [HttpPost]
        public IActionResult PostUser(User newUser)
        {
            if(newUser.UserName != null)
            {
                User createUser = new User
                {
                    UserName = newUser.UserName,
                    Name = newUser.Name,
                    Age = newUser.Age,
                    Address = newUser.Address,
                };
                foreach (var user in users)
                {
                    if (createUser.UserName == user.UserName)
                    {
                        return BadRequest("Already have this user");
                    }
                }
                users.Add(createUser);
                return Ok("Add success");
            }
            return BadRequest("Input is empty");
        }

        [HttpPut("{UserName}")]
        public IActionResult UpdateUser(string UserName, User updateuser)
        {
            if (UserName != updateuser.UserName)
            {
                return BadRequest("Not match with the input!");
            }
            
            foreach (var user in users)
            {
                if (UserName == user.UserName)
                {
                    user.Age = updateuser.Age;
                    user.Address = updateuser.Address;
                    return Ok("Success");
                }
            }
            return BadRequest("Cannot find user");
        }
        [HttpDelete("{UserName}")]
        public IActionResult DeleteUser(string UserName)
        {
            foreach(var user in users)
            {
                if(UserName == user.UserName)
                {
                    users.Remove(user);
                    return Ok("Complete Delete!");
                }    
            }
            return BadRequest("Cannot find user!");
        }
    }
}
