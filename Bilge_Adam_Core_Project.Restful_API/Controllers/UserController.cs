using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.BLL.Abstract;
using Bilge_Adam_Core_Project.BLL.Concreate;
using Bilge_Adam_Core_Project.Dal.Concreate;
using Bilge_Adam_Core_Project.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bilge_Adam_Core_Project.Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        readonly UserService _userService = new UserService(new UserRepository(), new Fav_Watch_List_Repository());

        // GET: api/User
        [HttpGet]
        public ICollection<User> GetUserList()
        {
            ICollection<User> users = new List<User>();
            foreach (var item in _userService.GetUserList())
            {
                item.Password = "******";
                users.Add(item);
            }
            return users;
        }

        [Route("[action]/{username}")]
        [HttpGet]
        public User GetUserByUserName(string username)
        {
            return _userService.GetUserByUserName(username);
        }
        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public User GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            user.Password = "******";
            return user;
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
        [Route("[action]/{userId}")]
        [HttpPost]
        public void AddMovieToWatch(int userId, Movie movie)
        {
            _userService.AddMovieToList(userId, movie, "Watch");
        }
        // POST: api/User/AddMovieToFav/4
        [Route("[action]/{userId}")]
        [HttpPost]
        public void AddMovieToFav(int userId, Movie movie)
        {
            _userService.AddMovieToList(userId, movie, "Favorite");
        }

        // PUT: api/User/UpdateUser
        [Route("[action]")]
        [HttpPut]
        public void UpdateUser([FromBody] User user)
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

        [Route("[action]/{userId}")]
        [HttpDelete]
        public void DeleteFavs(int userId, [FromBody]  Movie movie)
        {
            _userService.SoftDeleteMovieToList(userId, movie, "Favorite");
        }

        [Route("[action]/{userId}")]
        [HttpDelete("{userId}")]
        public void DeleteWatches(int userId, [FromBody]  Movie movie)
        {
            _userService.SoftDeleteMovieToList(userId, movie, "Watch");
        }
    }
}
