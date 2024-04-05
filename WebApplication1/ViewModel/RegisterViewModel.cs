using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "First Name Must be Less Than 50 Character ")
    , MinLength(3, ErrorMessage = "First Name Must be more Than 3 Character ")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "First Name Must be Less Than 50 Character ")
    , MinLength(3, ErrorMessage = "First Name Must be more Than 3 Character ")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Phone Number"),RegularExpression(@"^\d{11}$", ErrorMessage = "Phone Number must be 11 digit ")]
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

    }
}
