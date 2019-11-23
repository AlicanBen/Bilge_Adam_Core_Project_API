using Bilge_Adam_Core_Project.Core.Data;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Dal.Abstract
{
    public interface IUserRepository:IEntityRepository<User>
    {
        List<Movie> UserWatches(int userId);
        Task<List<Movie>> AsyncUserWatches(int userId);
        List<Movie> UserFavs(int userId);
        Task<List<Movie>> AsyncUserFavs(int userId);
    }
}
