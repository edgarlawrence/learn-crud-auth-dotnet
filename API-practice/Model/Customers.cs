using System.ComponentModel.DataAnnotations;

namespace API_practice.Model
{
    public class Customers
    {
        [Key]
        public string CustomerID { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
    }
}
