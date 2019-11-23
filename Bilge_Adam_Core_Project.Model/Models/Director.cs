using Bilge_Adam_Core_Project.Core.Entites;
using Bilge_Adam_Core_Project.Model.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bilge_Adam_Core_Project.Model.Models
{
    public class Director :Base,IEntity
    {
        public Director()
        {
            this.Movies = new HashSet<DirectorMovies>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }


        // navigation properties
        public virtual ICollection<DirectorMovies> Movies { get; set; }

    }
}
