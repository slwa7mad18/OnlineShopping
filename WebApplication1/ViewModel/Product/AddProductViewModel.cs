using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.ViewModel.Product
{
    public class AddProductViewModel
    {
        
        [MaxLength(50, ErrorMessage = "Product Name Must Be Less Than 50 Character")]
        [Remote(action: "CheckProduct", controller: "Product", ErrorMessage = "Product Name already Exists ")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Product Description Must Be Less Than 100 Character")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Choose Product Picture")]
        [Display(Name = "Product Picture")]
        public IFormFile ImgUrl { get; set; }

        [Range(1, 100000)]
        public double Price { get; set; }
        [Range(0, 10000)]
        public int Count { get; set; }

        [Display(Name = "Sellect Category")]
        public int CategoryId { get; set; }

    }
}
