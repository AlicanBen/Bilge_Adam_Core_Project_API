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
            return _iDirectorRepository.Add(director);
        }

        public async Task<bool> AddAsync(Director director)
        {
            return await _iDirectorRepository.AddAsync(director);

        }

        public List<Movie> DirectorMovies(int directorId)
        {
            return _iDirectorRepository.DirectorMovies(directorId);
        }

        public async Task<List<Movie>> DirectorMoviesAsync(int directorId)
        {
            return await _iDirectorRepository.AsyncDirectorMovies(directorId);

        }

        public Director GetDirectorById(int directorId)
        {
            return _iDirectorRepository.Get(x => x.Id == directorId);
        }

        public ICollection<Director> GetDirectorList()
        {
            return _iDirectorRepository.GetAll();
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
