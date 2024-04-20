using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.ViewModel.OrderItem
{
    public class OrderItemDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
