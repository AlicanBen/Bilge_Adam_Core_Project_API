using Bilge_Adam_Core_Project.BLL.Abstract;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.BLL.Concreate
{
    public class DirectorService : IDirectorService
    {
        IDirectorRepository _iDirectorRepository;
        public DirectorService(IDirectorRepository directorRepository)
        {
            _iDirectorRepository = directorRepository;
        }
        public bool Add(Director director)
        {
            director.DateOfAdd = DateTime.Now;
            return _iDirectorRepository.Add(director);
        }

        public async Task<bool> AddAsync(Director director)
        {
            return await _iDirectorRepository.AddAsync(director);

        }

        public List<Movie> DirectorMovies(int directorId)
        {
            List<Movie> movies = new List<Movie>();
            foreach (var item in _iDirectorRepository.DirectorMovies(directorId))
            {
                if (item.IsDelete == false)
                {
                    movies.Add(item);
                }
            }
            return movies;
        }

        public async Task<List<Movie>> DirectorMoviesAsync(int directorId)
        {
              List<Movie> movies = new List<Movie>();
            
           foreach ( var item  in _iDirectorRepository.DirectorMovies(directorId))
            {
                if (item.IsDelete == false)
                {
                    movies.Add(item);
                }
            }
            return  movies;

        }

        public Director GetDirectorById(int directorId)
        {
            return _iDirectorRepository.Get(x => x.Id == directorId && x.IsDelete==false);
        }

        public ICollection<Director> GetDirectorList()
        {
            List<Director> directors = new List<Director>();

            foreach (var item in _iDirectorRepository.GetAll())
            {
                if (item.IsDelete == false)
                {
                    directors.Add(item);
                }
            }
            return directors;
        }

        public bool SoftDelete(Director director)
        {
            director.IsDelete = true;
            return _iDirectorRepository.SoftDelete(director);
        }

        public async Task<bool> SoftDeleteAsync(Director director)
        {
            director.IsDelete = true;
            return await _iDirectorRepository.SoftDeleteAsync(director);
        }

        public bool Update(Director director)
        {
            return _iDirectorRepository.Update(director);
        }

        public async Task<bool> UpdateAsync(Director director)
        {
            return await _iDirectorRepository.UpdateAsync(director);
        }
    }
}
