using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Product Name Must Be Less Than 50 Character")]
        public string Name { get; set; }  

        [MaxLength(100, ErrorMessage = "Product Description Must Be Less Than 100 Character")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Choose Product Picture")]
        [Display(Name = "Product Picture")]
        public string ImgUrl { get; set; } 

        [Range(1, 100000)]
        public double Price { get; set; }
        [Range(0,10000)]
        public int Count { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
