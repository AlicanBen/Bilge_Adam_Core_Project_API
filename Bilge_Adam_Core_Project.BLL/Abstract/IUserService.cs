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
        ICollection<Movie> GetAllUserFavs(int userId);
        ICollection<Movie> GetAllUserWatches(int userId);
        bool Add(User user);
        bool AddMovieToList(int userId, Movie movie, string type);
        Task<bool> AddAsync(User user);
        bool SoftDelete(User user);
        Task<bool> SoftDeleteAsync(User user);
        bool SoftDeleteMovieToList(int userId, Movie movie,string type);
        bool Update(User user);
        Task<bool> UpdateAsync(User user);

    }
}
