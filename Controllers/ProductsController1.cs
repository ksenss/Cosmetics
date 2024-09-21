using Cosmetics.Helpers;
using Cosmetics.Models;
using data_access;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetics.Controllers
{
    public class ProductsController : Controller
    {
        //product list
        CosmeticsDbContex contex;
        public ProductsController()
        {
           contex= new CosmeticsDbContex(); 
        }
        public IActionResult Index()
        {
            //TODO : get data from DB
            return View(contex.Products.ToList());
            
        }
        public IActionResult Details(int id)
        {
            var product =contex.Products.Find(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = contex.Products.Find(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }
    }
}