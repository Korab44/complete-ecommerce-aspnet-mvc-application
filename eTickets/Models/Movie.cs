using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImageURL{ get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Movie Category")]
        public MovieCategory MovieCategory { get; set;}

        public List<Actor_Movie> Actors_Movies { get; set; }
        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }
    }
}
