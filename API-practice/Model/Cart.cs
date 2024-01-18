using System.ComponentModel.DataAnnotations;

namespace API_practice.Model
{
    public class Cart
    {
        public string Id { get; set; }
        public string MusicId { get; set; }
        public string Quantity { get; set; }

    }
}
