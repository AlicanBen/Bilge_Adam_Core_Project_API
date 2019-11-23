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
        public ICollection<User> GetUserList()
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
        public ICollection<Movie> GetUserFavs(int id)
        {
            return _userService.GetAllUserFavs(id);
        }


        // GET: api/User/GetUserWatches/1
        [Route("[action]/{id}")]
        [HttpGet]
        public ICollection<Movie> GetUserWatches(int id)
        {
            return _userService.GetAllUserWatches(id);
        }

      
        // POST: api/User
        [Route("[action]")]
        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _userService.Add(user);
        }
        // POST: api/User
        [Route("[action]")]
        [HttpPost("{userId}")]
        public void AddMovieToWatch(int userId,Movie movie)
        {
            _userService.AddMovieToList(userId,movie,"Watch");
        }
        // POST: api/User
        [Route("[action]")]
        [HttpPost("{userId}")]
        public void AddMovieToFav(int userId,Movie movie)
        {
            _userService.AddMovieToList(userId,movie,"Favorite");
        }

        // PUT: api/User/5
        [Route("[action]")]
        [HttpPut]
        public void UpdateUser( [FromBody] User user)
        {
            _userService.Update(user);
        }

        // DELETE: api/ApiWithActions/5
        [Route("[action]")]
        [HttpDelete]
        public void Delete([FromBody] User user)
        {
            _userService.SoftDelete(user);
        }

        [Route("[action]")]
        [HttpDelete("{userId}")]
        public void DeleteFavs(int userId,[FromBody]  Movie movie)
        {
            _userService.SoftDeleteMovieToList(userId, movie,"Favorite");
        }

        [Route("[action]")]
        [HttpDelete("{userId}")]
        public void DeleteWatches(int userId, [FromBody]  Movie movie)
        {
            _userService.SoftDeleteMovieToList(userId, movie,"Watch");
        }
    }
}
