using Bilge_Adam_Core_Project.Core.Entites;
using Bilge_Adam_Core_Project.Model.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bilge_Adam_Core_Project.Model.Models
{
    public class DirectorMovies:Base,IEntity
    {
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
        public int DirectorId { get; set; }
        [JsonIgnore]
        public Director Director { get; set; }
    }
}
