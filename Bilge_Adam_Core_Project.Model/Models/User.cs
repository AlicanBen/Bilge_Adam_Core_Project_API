using Bilge_Adam_Core_Project.Core.Entites;
using Bilge_Adam_Core_Project.Model.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bilge_Adam_Core_Project.Model.Models
{
    public class User:Base, IEntity
    {
        public User()
        {
            this.Fav_Watch_List =  new HashSet<Fav_Watch_List>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Fav_Watch_List> Fav_Watch_List { get; set; }
    }
}
