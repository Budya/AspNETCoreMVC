using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using _01HelloWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _01HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UsersContext db;

        public UsersController(UsersContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Tom", Age = 26 });
                db.Users.Add(new User { Name = "Alice", Age = 31 });
                db.SaveChanges();
            }

        }

        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                ModelState.AddModelError("", "Не указаны данные для пользователя");
                return BadRequest();
            }
            if (user.Age==99)
                ModelState.AddModelError("Age", "Возраст не должен быть равен 99");
 
            if (user.Name == "admin")
            {
                ModelState.AddModelError("Name", "Недопустимое имя пользователя - admin");
            }
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
