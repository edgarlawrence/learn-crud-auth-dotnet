namespace API_practice.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public Music Music { get; set; }
        public int Quantity { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Music.Price * Quantity;
        }
    }
}
