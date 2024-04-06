using OnlineShopping.Reposatory;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace OnlineShopping.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repository = (IReposatory<Category>)validationContext.GetService(typeof(IReposatory<Category>));
            var category = (Category)validationContext.ObjectInstance;


            var existingCategory = repository.GetAll().FirstOrDefault(c => c.Name == (string)value && c.Id != category.Id);

            if (existingCategory != null)
            {
                return new ValidationResult("Category already exist");
            }

            return ValidationResult.Success;
        }
    }
}
