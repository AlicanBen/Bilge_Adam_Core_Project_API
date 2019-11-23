using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.BLL.Abstract;
using Bilge_Adam_Core_Project.BLL.Concreate;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Bilge_Adam_Core_Project.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bilge_Adam_Core_Project.Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService = new UserService(new UserRepository(),new Fav_Watch_List_Repository());
     
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUserList()
        {
            return _userService.GetUserList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        // GET: api/User/GetUserFavs/1
        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<Fav_Watch_List> GetUserFavs(int id)
        {
            return _userService.GetAllUserFavs(id);
        }


        // GET: api/User/GetUserWatches/1
        [Route("[action]/{id}")]
        [HttpGet]
        public IEnumerable<Fav_Watch_List> GetUserWatches(int id)
        {
            return _userService.GetAllUserWatches(id);
        }

      
        // POST: api/User
        [Route("[action]")]
        [HttpPost]
        public void Add([FromBody] User user)
        {
            _userService.Add(user);
        }

        // PUT: api/User/5
        [Route("[action]")]
        [HttpPut]
        public void Put( [FromBody] User user)
        {
            _userService.Update(user);
        }

        // DELETE: api/ApiWithActions/5
        [Route("[action]")]
        [HttpDelete("{id}")]
        public void Delete([FromBody] User user)
        {
            _userService.SoftDelete(user);
        }
    }
}
