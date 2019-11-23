using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.BLL.Abstract
{
    public interface IMovieService
    {
        Movie GetMovieById(int movieId);
        ICollection<Movie> GetMovieList();
        bool Add(Movie movie);
        Task<bool> AddAsync(Movie movie);
        bool SoftDelete(Movie movie);
        Task<bool> SoftDeleteAsync(Movie movie);
        bool Update(Movie movie);
        Task<bool> UpdateAsync(Movie movie);
        List<Director> MovieDirectors(int movieId);
        Task<List<Director>> MovieDirectorsAsync(int movieId);
    }
}
