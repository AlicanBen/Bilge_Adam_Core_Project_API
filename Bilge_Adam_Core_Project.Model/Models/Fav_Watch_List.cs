using Bilge_Adam_Core_Project.Core.Entites;
using Bilge_Adam_Core_Project.Model.Bases;
using System.ComponentModel.DataAnnotations;

namespace Bilge_Adam_Core_Project.Model.Models
{
    public class Fav_Watch_List:Base,IEntity
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public string ListType { get; set; }
    }
}