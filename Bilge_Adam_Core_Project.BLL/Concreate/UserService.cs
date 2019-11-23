using Bilge_Adam_Core_Project.BLL.Abstract;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.BLL.Concreate
{
    public class UserService : IUserService
    {
        readonly I_Fav_Watch_List  _i_Fav_Watch_List;
        readonly IUserRepository   _iUserRepository;
        public UserService(IUserRepository userRepository, I_Fav_Watch_List i_Fav_Watch_List)
        {
            _iUserRepository = userRepository;
            _i_Fav_Watch_List = i_Fav_Watch_List;
        }
        public bool Add(User user)
        {
            user.DateOfAdd = DateTime.Now;
            return _iUserRepository.Add(user);
        }

        public async Task<bool> AddAsync(User user)
        {
            return await _iUserRepository.AddAsync(user);
        }



      
        public User GetUserById(int userId)
        {
            return _iUserRepository.Get(x => x.Id == userId);
        }

        public ICollection<Movie> GetAllUserFavs(int userId)
        {
            return _iUserRepository.UserFavs(userId);
        }

        public ICollection<User> GetUserList()
        {
            return _iUserRepository.GetAll();
        }

        public ICollection<Movie> GetAllUserWatches(int userId)
        {
            return _iUserRepository.UserWatches(userId);
        }

        public bool SoftDelete(User user)
        {
            user.IsDelete = true;
            return _iUserRepository.SoftDelete(user);
        }

        public async Task<bool> SoftDeleteAsync(User user)
        {
            user.IsDelete = true;
            return await _iUserRepository.SoftDeleteAsync(user);
        }

 

        public bool Update(User user)
        {
            return _iUserRepository.Update(user);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            return await _iUserRepository.UpdateAsync(user);
        }

      

        public bool AddMovieToList(int userId,  Movie movie, string type)
        {
            Fav_Watch_List fav_Watch = new Fav_Watch_List
            {
                Movie = movie,
                MovieId = movie.Id,
                User = _iUserRepository.Get(x => x.Id == userId),
                UserId = userId,
                IsDelete = false,
                ListType =type,
                DateOfAdd = DateTime.Now
            };
            return _i_Fav_Watch_List.Add(fav_Watch);

        }

        public bool SoftDeleteMovieToList(int userId, Movie movie, string type)
        {
            Fav_Watch_List fav_Watch = new Fav_Watch_List
            {
                Movie = movie,
                MovieId = movie.Id,
                User = _iUserRepository.Get(x => x.Id == userId),
                UserId =userId,
                IsDelete = false,
                ListType =type,
                DateOfAdd = DateTime.Now
            };
            return _i_Fav_Watch_List.SoftDelete(fav_Watch);
        }
    }
}
