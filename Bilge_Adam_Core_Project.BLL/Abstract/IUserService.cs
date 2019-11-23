using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.BLL.Abstract
{
    public interface IUserService
    {
        User GetUserById(int userId);
        ICollection<User> GetUserList();
        ICollection<Fav_Watch_List> GetAllUserFavs(int userId);
        ICollection<Fav_Watch_List> GetAllUserWatches(int userId);
        bool Add(User user);
        bool AddMovieToList(User user, Movie movie,string type);
        Task<bool> AddAsync(User user);
        bool SoftDelete(User user);
        Task<bool> SoftDeleteAsync(User user);
        bool SoftDeleteMovieToList(Fav_Watch_List fav_Watch_List);
        bool Update(User user);
        Task<bool> UpdateAsync(User user);

    }
}
