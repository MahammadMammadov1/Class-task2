using Class.DAL;
using Class.Models;
using Class.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Class.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDb;

        public HomeController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();  
            model.Products = _appDb.Products.ToList();
            model.Catagories = _appDb.Catagories.ToList();
            model.Colours = _appDb.Colors.ToList();

            return View(model);
        }
    }
}
