using Bilge_Adam_Core_Project.Core.Data;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Dal.Abstract
{
    public interface IDirectorRepository : IEntityRepository<Director>
    {
        public List<Movie> DirectorMovies(int directorId);
        public Task<List<Movie>> AsyncDirectorMovies(int directorId);
    }
}
