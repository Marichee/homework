using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Exercise._01.Controllers
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>()
       {
         new User(){ FirstName = "Marija",LastName ="Prosheva",Age = 20},
         new User(){FirstName = "Elena",LastName = "Ristova",Age = 15},
         new User(){FirstName = "Zoran",LastName = "Pizevski",Age = 25}
       };
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return users;
        }
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            try
            {
                return users[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id {id} does not exist");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [HttpGet("{checkId}/checkAdult")]
        public ActionResult<string> CheckAdult(int checkId)
        {
            try
            {
                if (users[checkId - 1].Age >= 18)
                {
                    return $"User is adult";
                }
                else
                {
                    return $"User is not adult";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id {checkId} does not exist");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost]
        public IActionResult Post()
        {
            string body;
            using(StreamReader sr = new StreamReader(Request.Body))
            {
                body = sr.ReadToEnd();
            }
            User user = JsonConvert.DeserializeObject<User>(body);
            users.Add(user);
            return Ok($"User with id {users.Count} is added!");
        }
    }
}
