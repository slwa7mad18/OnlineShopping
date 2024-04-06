using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
       
        [MaxLength(50, ErrorMessage = "First Name Must be Less Than 50 Character ")
            ,MinLength(3, ErrorMessage = "First Name Must be more Than 3 Character ")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last Name Must be Less Than 50 Character ")
            , MinLength(3, ErrorMessage = "Last Name Must be more Than 3 Character ")]
        public string LastName { get; set; }

        public string? Adress { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone Number must be 11 digit ")]
        public string PhoneNumber { get; set; }
    }
}
