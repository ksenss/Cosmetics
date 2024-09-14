using Cosmetics.Helpers;
using Cosmetics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetics.Controllers
{
    public class ProductsController : Controller
    {
        //product list
        List<Product> products;
        public ProductsController()
        {
            products = new List<Product>(Seeder.GetProducts());
        }
        public IActionResult Index()
        {
            //TODO : get data from DB
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null) { return NotFound(); }
            return View(product);
        }
    }
}