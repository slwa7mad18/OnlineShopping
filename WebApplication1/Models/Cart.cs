namespace WebApplication1.Models
{
    public class Cart
    {
        public int Id { get; set; }
        List<OrderItem> OrderItems { get; set; }
    }
}
