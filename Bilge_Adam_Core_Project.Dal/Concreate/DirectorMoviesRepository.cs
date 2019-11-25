using Bilge_Adam_Core_Project.Core.Data.EFCore;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{
    class DirectorMoviesRepository : EFEntityRepositoryBase<DirectorMovies, BilgeAdamCoreProjectContext>, IDirectorMovies
    {
    }
}
