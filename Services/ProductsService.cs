
using data_access.Entities;
using data_access;


using Microsoft.EntityFrameworkCore;

namespace Cosmetics.Services
{
    public interface IProductService
    {
       
        List<Product> GetAll();
        List<Product> Get(int[] ids);
        List<Category> GetCategories();
        Product? GetById(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly CosmeticsDbContex context;

    public ProductService(CosmeticsDbContex context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var find = context.Products.Find(id);
           
            if (find == null) return;

            context.Products.Remove(find);
            context.SaveChanges();
            
        }

        public void Edit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();

        }

        public List<Product> Get(int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();

        }

        public Product? GetById(int id)
        {
            if (id < 0) { return null; }

           var product = context.Products.Find(id);
           

            if (product == null) { return null; }
            return product;
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}