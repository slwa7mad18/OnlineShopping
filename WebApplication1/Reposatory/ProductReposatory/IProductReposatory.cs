using OnlineShopping.ViewModel.Product;
using WebApplication1.Models;

namespace OnlineShopping.Reposatory.ProductReposatory
{
    public interface IProductReposatory
    {
        List<Product> GetAll();
        Product GetById(int Id);
        Product GetProductWithoutReviews(int Id);
        void Insert(Product product);
        void Update(EditProductViewModel product);
        void Delete(int id);
        void Save();
        string UploadFile(IFormFile model);
        bool CheckProduct(string Name);
        bool CheckProductToEdit(string Name, int Id);

        List<Product> GetProducts(List<int>? _productsSelected);
        List<Product> GetProductsByCategory(int categoryId);
    }
}
