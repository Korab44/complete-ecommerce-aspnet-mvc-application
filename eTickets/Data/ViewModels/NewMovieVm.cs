using eTickets.Data.Base;
using eTickets.Data.Enums;
using eTickets.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVm
    {
        public int Id { get; set; }
        [Display(Name = "Movie name")]
        public string Name { get; set; }
        [Display(Name = "Movie description")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        public double Price { get; set; }
        [Display(Name = "Movie poste URL")]
        public string ImageURL{ get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set;}
        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select a cinema")]
        public int CinemaID { get; set; }
        [Display(Name = "Select a producer")]
        public int ProducerID { get; set; }
    }
}
