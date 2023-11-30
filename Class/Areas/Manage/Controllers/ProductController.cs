using Class.DAL;
using Class.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Class.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDb;

        public ProductController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            List<Product> products = _appDb.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        { 
            ViewBag.Colors = _appDb.Colors.ToList();
            ViewBag.Catagory = _appDb.Catagories.ToList();

            if (!ModelState.IsValid) { return View(); }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Colors = _appDb.Colors.ToList();
            ViewBag.Catagory = _appDb.Catagories.ToList();
            if (!ModelState.IsValid)  return View(); 
            if (product.ProductHower != null)
            {
                string filename = product.ProductHower.FileName + Guid.NewGuid().ToString();
                if (!ModelState.IsValid) return View();
                if (product == null) { return NotFound(); }

                string path = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Class\\Class\\wwwroot\\upload\\products\\" + filename;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.ProductHower.CopyTo(stream);
                }

                ProductImage image = new ProductImage 
                {
                    Product  = product,
                    ImageUrl = filename,
                    isPoster = false,
                };
                _appDb.ProductImages.Add(image);
                _appDb.SaveChanges();
            }

            if (product.ProductPoster != null)
            {
                string filename = product.ProductPoster.FileName + Guid.NewGuid().ToString();
                if (!ModelState.IsValid) return View();
                if (product == null) { return NotFound(); }

                string path = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Class\\Class\\wwwroot\\upload\\products\\" + filename;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.ProductPoster.CopyTo(stream);
                }

                ProductImage image = new ProductImage
                {
                    Product = product,
                    ImageUrl = filename,
                    isPoster = true,
                };

                _appDb.ProductImages.Add(image);    
                _appDb.SaveChanges();
            }

            if (product.ImageFiles != null)
            {
                string filename = product.ProductPoster.FileName + Guid.NewGuid().ToString();
                if (!ModelState.IsValid) return View();
                if (product == null) { return NotFound(); }

                string path = "C:\\Users\\II Novbe\\Desktop\\TasksCode\\Class\\Class\\wwwroot\\upload\\products\\" + filename;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.ProductPoster.CopyTo(stream);
                }

                ProductImage image = new ProductImage
                {
                    Product = product,
                    ImageUrl = filename,
                    isPoster = null,
                };
                _appDb.ProductImages.Add(image);
                _appDb.SaveChanges();
            }

            _appDb.Products.Add(product);
            _appDb.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}
