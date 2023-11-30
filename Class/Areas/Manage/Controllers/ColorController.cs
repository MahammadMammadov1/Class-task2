using Class.DAL;
using Class.Models;
using Microsoft.AspNetCore.Mvc;


namespace Class.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ColorController : Controller
    {
        private readonly AppDbContext _appDb;

        public ColorController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            List<Colour> catagories = _appDb.Colors.ToList();
            return View(catagories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Colour color)
        {
            if (!ModelState.IsValid) return View(color);
            if (_appDb.Colors.Any(x => x.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "color already exist!");
                return View(color);
            }

            _appDb.Colors.Add(color);
            _appDb.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var wanted = _appDb.Colors.FirstOrDefault(x => x.Id == id);
            if (wanted == null) return NotFound();
            return View(wanted);
        }
        [HttpPost]
        public IActionResult Update(Colour color)
        {
            var existColor = _appDb.Colors.FirstOrDefault(x => x.Id == color.Id);
            if (existColor == null) return NotFound();
            if (!ModelState.IsValid) return View(color);
            if (_appDb.Colors.Any(x => x.Id != color.Id && x.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "color already exist!");
                return View(color);
            }
            existColor.Name = color.Name;
            _appDb.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var wanted = _appDb.Colors.FirstOrDefault(x => x.Id == id);
            if (wanted == null) return NotFound();
            return View(wanted);
        }
        [HttpPost]
        public IActionResult Delete(Colour color)
        {
            var wanted = _appDb.Colors.FirstOrDefault(x => x.Id == color.Id);
            if (wanted == null) return NotFound();
            _appDb.Colors.Remove(wanted);
            _appDb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
