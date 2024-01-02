using API_practice.Model;
using System.ComponentModel.DataAnnotations;

namespace API_practice.DTO
{
    public class GenreDTO
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
