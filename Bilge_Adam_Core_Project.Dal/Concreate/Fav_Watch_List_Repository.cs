using Bilge_Adam_Core_Project.Core.Data.EFCore;
using Bilge_Adam_Core_Project.Dal.Abstract;
using Bilge_Adam_Core_Project.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge_Adam_Core_Project.Dal.Concreate
{
    public class Fav_Watch_List_Repository : EFEntityRepositoryBase<Fav_Watch_List, BilgeAdamCoreProjectContext>, I_Fav_Watch_List
    {
        public bool addToList(Fav_Watch_List list)
        {

           Fav_Watch_List isCont= this.Get(x => x.MovieId == list.MovieId && x.UserId == list.UserId && x.ListType == list.ListType);
            if (isCont == null)
            {
                return this.Add(list);
            }
            else {
                isCont.IsDelete = false;
                
                return this.Update(isCont); }
        }
    }
}
