using System.ComponentModel.DataAnnotations;

namespace API_practice.Model
{
    public class Genre
    {
        [Key] 
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Music> Music { get; set; }
    }
}
