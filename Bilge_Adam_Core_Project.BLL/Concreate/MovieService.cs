using System;
using System.Collections.Generic;
using Bilge_Adam_Core_Project.BLL.Abstract;
using System.Text;
using Bilge_Adam_Core_Project.Model.Models;
using System.Threading.Tasks;
using Bilge_Adam_Core_Project.Dal.Abstract;

namespace Bilge_Adam_Core_Project.BLL.Concreate
{
    public class MovieService : IMovieService
    {
        readonly IMovieRepository _iMovieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _iMovieRepository = movieRepository;
        }
        public bool Add(Movie movie)
        {
            movie.DateOfAdd = DateTime.Now;
            return _iMovieRepository.Add(movie);
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            return await _iMovieRepository.AddAsync(movie);
        }

        public Movie GetMovieById(int movieId)
        {
            Movie movie = _iMovieRepository.Get(x => x.Id == movieId&&x.IsDelete==false);
            movie.ReleaseDate = new DateTime(movie.ReleaseDate.Year, movie.ReleaseDate.Month, movie.ReleaseDate.Day);
            return  movie;
        }

        public ICollection<Movie> GetMovieList()
        {
            List<Movie> movies = new List<Movie>();
            foreach (var item in _iMovieRepository.GetAll())
            {
                item.ReleaseDate = new DateTime(item.ReleaseDate.Year, item.ReleaseDate.Month, item.ReleaseDate.Day);
                if (item.IsDelete == false) { 
                movies.Add(item);
                }
            }
            return movies;
        }

        public List<Director> MovieDirectors(int movieId)
        {
            List<Director> directors = new List<Director>();
            foreach (var item in _iMovieRepository.MovieDirectors(movieId))
            {
                if (item.IsDelete == false)
                {
                    directors.Add(item);
                }
            }
            return directors;
        }

        public async Task<List<Director>> MovieDirectorsAsync(int movieId)
        {
            return await _iMovieRepository.AsyncMovieDirectors(movieId);
        }

        public bool SoftDelete(Movie movie)
        {
            movie.IsDelete = true;
            return _iMovieRepository.SoftDelete(movie);
        }

        public async Task<bool> SoftDeleteAsync(Movie movie)
        {
            movie.IsDelete = true;
            return await _iMovieRepository.SoftDeleteAsync(movie);
        }

        public bool Update(Movie movie)
        {
            return _iMovieRepository.Update(movie);
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            return await _iMovieRepository.UpdateAsync(movie);
        }
    }
}
