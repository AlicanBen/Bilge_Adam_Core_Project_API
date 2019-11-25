using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.Core.Data.EFCore;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{
    public class UserRepository : EFEntityRepositoryBase<User, BilgeAdamCoreProjectContext>, IUserRepository
    {
        public async Task<List<Movie>> AsyncUserFavs(int userId)
        {
            List<Movie> userFavs = new List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                foreach (var item in context.List
                    .Where(x => x.UserId == userId && x.ListType == "Favorite" && x.IsDelete == false)
                    .ToList())
                {
                    userFavs.Add(await context.Movie.FindAsync(item.MovieId));
                }
            }
            return userFavs;
        }
        public List<Movie> UserFavs(int userId)
        {
            List<Movie> userFavs = new List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                foreach (var item in context.List
                    .Where(x => x.UserId == userId && x.ListType == "Favorite" && x.IsDelete==false)
                    .ToList())
                {
                    userFavs.Add( context.Movie.Find(item.MovieId));
                }
            }
            return userFavs;
        }
        public async Task<List<Movie>> AsyncUserWatches(int userId)
        {
            List<Movie> userWatchs = new List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                foreach (var item in context.List
                    .Where(x => x.UserId == userId && x.ListType == "Watch")
                    .ToList())
                {
                    userWatchs.Add(await context.Movie.FindAsync(item.MovieId));
                }
            }
            return userWatchs;
        }

   

        public List<Movie> UserWatches(int userId)
        {
            List<Movie> userWatchs = new List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                foreach (var item in context.List
                    .Where(x => x.UserId == userId && x.ListType == "Watch" && x.IsDelete == false)
                    .ToList())
                {
                    userWatchs.Add(context.Movie.Find(item.MovieId));
                }
            }
            return userWatchs;
        }
    }
}
