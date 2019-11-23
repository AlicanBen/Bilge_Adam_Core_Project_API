using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.BLL.Abstract
{
    public interface IDirectorService
    {
        ICollection<Director> GetDirectorList();
        Director GetDirectorById(int directorId);
        bool Add(Director director);
        Task<bool> AddAsync(Director director);
        bool SoftDelete(Director director);
        Task<bool> SoftDeleteAsync(Director director);
        bool Update(Director director);
        Task<bool> UpdateAsync(Director director);
        List<Movie> DirectorMovies(int directorId);
        Task<List<Movie>> DirectorMoviesAsync(int directorId);
    }
}
