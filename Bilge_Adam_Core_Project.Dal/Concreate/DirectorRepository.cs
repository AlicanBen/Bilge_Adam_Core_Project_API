using Bilge_Adam_Core_Project.Core.Data.EFCore;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{

    public class DirectorRepository : EFEntityRepositoryBase<Director, BilgeAdamCoreProjectContext>, IDirectorRepository
    {
        
        public async Task<List<Movie>> AsyncDirectorMovies(int directorId)
        {
            List<Movie>  directorMovies=new  List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext()) {
               List<DirectorMovies> tmpList=  context.DirectorMovies.Where(x => x.DirectorId == directorId).ToList();
                 foreach (var item in tmpList)
                {
                    directorMovies.Add(await context.Movie.FindAsync(item.MovieId));
                }
            }
            return  directorMovies;
        }

        public List<Movie> DirectorMovies(int directorId)
        {
            List<Movie> directorMovies = new List<Movie>();
            using (var context = new BilgeAdamCoreProjectContext())
            {
                List<DirectorMovies> tmpList = context.DirectorMovies.Where(x => x.DirectorId == directorId).ToList();
                foreach (var item in tmpList)
                {
                    directorMovies.Add(context.Movie.Find(item.MovieId));
                }
            }
            return directorMovies;
        }
    }
}
