using OnlineShopping.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Name must contain at least 2 letters")]
       // [MaxLength(50, ErrorMessage = "category Name Must Be Less Than 50 Character ")]
        [Unique]
        public string Name { get; set; }
        public List<Product> ?Products { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
