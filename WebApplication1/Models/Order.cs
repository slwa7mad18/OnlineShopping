using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double Cost { get; set; }

        [MaxLength(100, ErrorMessage = "Destination Must Be Less Than 100 Character ")]
        public string Destination { get; set; }

        public bool IsConfirmed { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<OrderItem> orderItems { get; set; }

    }
}
