using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
       
        public string ProfilePictureURL  { get; set; }

        [Display(Name = "Full Name")]
       
        public string FullName { get; set;}

        [Display(Name = "BIO")]
        
        public string BIO { get; set;}
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
 