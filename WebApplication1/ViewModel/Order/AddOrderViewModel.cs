using OnlineShopping.ViewModel.OrderItem;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.ViewModel.Order
{
    public class AddOrderViewModel
    {
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double Cost { get; set; }

        public string Destination { get; set; }

        public bool IsConfirmed { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public List<OrderItemDetailsViewModel> OrderItems{ get; set;}
    }
}
