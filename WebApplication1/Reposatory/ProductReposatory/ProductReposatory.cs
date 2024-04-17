using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.ViewModel.Product;
using WebApplication1.Models;

namespace OnlineShopping.Reposatory.ProductReposatory
{
    public class ProductReposatory: IProductReposatory
    {
        public Context Context { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductReposatory(Context context, IWebHostEnvironment webHostEnvironment)
        {
            Context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public List<Product> GetAll()
        {
            return Context.Products.Include(p=>p.Category).Include(p=>p.Reviews).ToList();
        }
        public Product GetById(int Id) 
        {
            return Context.Products.FirstOrDefault(p => p.Id == Id);
        }


        public bool CheckProduct(string Name)
        {
            return Context.Products.SingleOrDefault(p => p.Name.ToLower() == Name.ToLower())==null;
        }
        public bool CheckProductToEdit(string Name,int Id)
        {
            return Context.Products.SingleOrDefault(p=>p.Id != Id && p.Name.ToLower()==Name.ToLower())==null;
        }

        public void Insert(Product model)
        {
            Context.Add(model);
        }

        public void Update(EditProductViewModel product)
        {
            Product productFromDB=GetById(product.Id);

            productFromDB.Name = product.Name;
            productFromDB.Price = product.Price;
            productFromDB.Description = product.Description;
            productFromDB.CategoryId = product.CategoryId;
            productFromDB.Count = product.Count;

            if (product.ImgUrl != null) 
            {
                productFromDB.ImgUrl = UploadFile(product.ImgUrl);
               
            }
           
           Context.Update(productFromDB);
        }
        public void Delete(int id)
        {
            Product product = GetById(id);
            string deleteFileFromFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFileFromFolder,product.ImgUrl);
            Context.Remove(product);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
           
           
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public Product GetProductWithoutReviews(int Id)
        {
            return Context.Products.Where(c => c.Id == Id).Include(c => c.Reviews).SingleOrDefault();
        }

        public string UploadFile(IFormFile formFile)
        {
            string uniqueName = null;
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            uniqueName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string filePath = Path.Combine(path, uniqueName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return uniqueName;

        }



        public List<Product> GetProducts(List<int> prodlist)
        {
            var products = new List<Product>();
            foreach (int prod in prodlist)
            {
                GetById(prod);
                products.Add(GetById(prod));
            }
            return products;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return Context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }


        
    }






