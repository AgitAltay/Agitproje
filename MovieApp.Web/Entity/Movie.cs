using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class Movie
    {


        
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string Director { get; set; }

        public string[] Actors { get; set; }

        public string ImageUrl { get; set; }
       
        public int GenreId { get; set; }




    }
}
