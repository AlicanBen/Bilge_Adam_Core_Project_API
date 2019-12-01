using Bilge_Adam_Core_Project.Core.Data.EFCore;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{
    public class MovieRepository : EFEntityRepositoryBase<Movie, BilgeAdamCoreProjectContext>, IMovieRepository
    {
        public async Task<List<Director>> AsyncMovieDirectors(int movieId)
        {
            List<Director> movieDirectors = new List<Director>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                List<DirectorMovies> tmpList = context.DirectorMovies.Where(x => x.MovieId == movieId &&x.IsDelete==false).ToList();
                foreach (var item in tmpList)
                {
                    movieDirectors.Add(await context.Director.FindAsync(item.DirectorId));
                }
            }
            return movieDirectors;
        }

        public List<Director> MovieDirectors(int movieId)
        {
            List<Director> movieDirectors = new List<Director>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                List<DirectorMovies> tmpList = context.DirectorMovies.Where(x => x.MovieId == movieId && x.IsDelete == false).ToList();
                foreach (var item in tmpList)
                {
                    movieDirectors.Add(context.Director.Find(item.DirectorId));
                }
            }
            return movieDirectors;
        }

    }
}
