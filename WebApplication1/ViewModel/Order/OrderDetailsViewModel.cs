using WebApplication1.Models;

namespace OnlineShopping.ViewModel.Order
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double Cost { get; set; }

        public string Destination { get; set; }

        public bool IsConfirmed { get; set; }
       // public List<OrderItem> orderItems { get; set; }
    }
}
