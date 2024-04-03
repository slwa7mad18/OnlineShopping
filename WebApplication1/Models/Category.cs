using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "category Name Must Be Less Than 50 Character ")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
