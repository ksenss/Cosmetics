using Cosmetics.Helpers;
using Cosmetics.Models;
using data_access;
using data_access.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cosmetics.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CosmeticsDbContex contex; // Fixed typo

        public ProductsController(CosmeticsDbContex context) // Use dependency injection
        {
            contex = context;
        }

        public IActionResult Index()
        {
            return View(contex.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = contex.Products.Find(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = contex.Products.Find(id);
            if (product == null) { return NotFound(); }
            contex.Products.Remove(product);
            contex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(contex.Categories.ToList(),
                nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price must be greater than 0.");
                LoadCategories();
                return View(product);
            }

            if (ModelState.IsValid) // Ensure validation is checked
            {
                contex.Products.Add(product);
                contex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            LoadCategories();
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = contex.Products.Find(id); // Fixed typo
            if (product == null) return NotFound();
            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            contex.Products.Update(product);
            contex.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(contex.Categories.ToList(),
                nameof(Category.Id), nameof(Category.Name));
        }
    }
}
