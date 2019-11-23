﻿using Bilge_Adam_Core_Project.Core.Entites;
using Bilge_Adam_Core_Project.Model.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bilge_Adam_Core_Project.Model.Models
{
    public class Movie:Base, IEntity
    {
        public Movie()
        {
            this.Directors = new HashSet<DirectorMovies>();
            this.Fav_Watch_List = new HashSet<Fav_Watch_List>();
        }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double ImdbRating { get; set; }


        // navigation properties
        public virtual ICollection<DirectorMovies> Directors { get; set; }
        public virtual ICollection<Fav_Watch_List> Fav_Watch_List { get; set; }

    }
}