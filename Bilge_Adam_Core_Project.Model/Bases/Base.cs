using Bilge_Adam_Core_Project.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bilge_Adam_Core_Project.Model.Bases
{
    public class Base:IEntity
    {
        public int Id { get; set; }
        public DateTime DateOfAdd { get; set; }
        public bool IsDelete { get; set; }
    }
}
