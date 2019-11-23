using Bilge_Adam_Core_Project.Core.Data;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Dal.Abstract
{
    public interface IMovieRepository : IEntityRepository<Movie>
    {
        List<Director> MovieDirectors(int movieId);
        Task<List<Director>> AsyncMovieDirectors(int movieId);

       

    }
}
