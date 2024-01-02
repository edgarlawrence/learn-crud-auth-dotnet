using System.ComponentModel.DataAnnotations;

namespace API_practice.Model
{
    public class Music
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Artist { get; set; }
        public int Rate { get; set; }

        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
