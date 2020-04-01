using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JemenaGasMeter.WebApi.Data;
using JemenaGasMeter.WebApi.Models;
using JemenaGasMeter.WebApi.Repository;

namespace JemenaGasMeter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }


        // Returns true if username and password matches the user
        // GET: api/user/1/1234
        // return true or false
        [HttpGet]
        [Route("{id}/{pin}")]
        public bool LoggedUser(string id, string pin)
        {
            bool user = _repo.LoginUser(id, pin);
            if(user != false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Returns all user
        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll();
        }

        // Returns particular user 
        // GET api/user/1
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _repo.Get(id);
        }

        // Below code are implemented for the future. 
        // Note: Do not delete it

        //// POST api/user
        //[HttpPost]
        //public void Post([FromBody] User user)
        //{
        //    _repo.Add(user);
        //}

        //// PUT api/user
        //[HttpPut]
        //public void Put([FromBody] User user)
        //{
        //    _repo.Update(user.PayRollID, user);
        //}

        //// DELETE api/user/1
        //[HttpDelete("{id}")]
        //public string Delete(string id)
        //{
        //    return _repo.Delete(id);
        //}
    }
}
