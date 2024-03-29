﻿using Bilge_Adam_Core_Project.BLL.Abstract;
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
        readonly I_Fav_Watch_List _i_Fav_Watch_List;
        readonly IUserRepository _iUserRepository;
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
            return _iUserRepository.Get(x => x.Id == userId && x.IsDelete == false);
        }
        public User GetUserByUserName(string username)
        {
            return _iUserRepository.Get(x => x.Username == username && x.IsDelete == false);
        }
        public ICollection<Movie> GetAllUserFavs(int userId)
        {

            List<Movie> userfavs = new List<Movie>();
            foreach (var item in _iUserRepository.UserFavs(userId))
            {
                if (item.IsDelete == false)
                {
                    userfavs.Add(item);
                }
            }
            return userfavs;
        }

        public ICollection<User> GetUserList()
        {
            List<User> users = new List<User>();
            foreach (var item in _iUserRepository.GetAll())
            {
                if (item.IsDelete == false)
                {
                    users.Add(item);
                }
            }
            return _iUserRepository.GetAll();
        }

        public ICollection<Movie> GetAllUserWatches(int userId)
        {
            List<Movie> userwatches = new List<Movie>();
            foreach (var item in _iUserRepository.UserWatches(userId))
            {
                if (item.IsDelete == false)
                {
                    userwatches.Add(item);
                }
            }
            return userwatches;
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



        public bool AddMovieToList(int userId, Movie movie, string type)
        {
            Fav_Watch_List fav_Watch = new Fav_Watch_List
            {
                Movie = movie,
                MovieId = movie.Id,
                User = _iUserRepository.Get(x => x.Id == userId),
                UserId = userId,
                IsDelete = false,
                ListType = type,
                DateOfAdd = DateTime.Now
            };
          
            return _i_Fav_Watch_List.addToList(fav_Watch);

        }

        public bool SoftDeleteMovieToList(int userId, Movie movie, string type)
        {
            Fav_Watch_List fav_Watch = _i_Fav_Watch_List.Get(x => x.Movie == movie &&
                x.UserId == userId && x.ListType == type);
            fav_Watch.IsDelete = true;
            return _i_Fav_Watch_List.SoftDelete(fav_Watch);
        }
    }
}
