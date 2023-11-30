using Class.DAL;
using Class.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class.Areas.Manage.Controllers
{
        [Area("Manage")]
        public class CatagoryController : Controller
        {
            private readonly AppDbContext _appDb;

            public CatagoryController(AppDbContext appDb)
            {
                _appDb = appDb;
            }
            public IActionResult Index()
            {
                List<Catagory> catagories = _appDb.Catagories.ToList();
                return View(catagories);
            }

            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Catagory catagory)
            {
                if (!ModelState.IsValid) return View(catagory);
                if (_appDb.Catagories.Any(x => x.Name.ToLower() == catagory.Name.ToLower()))
                {
                    ModelState.AddModelError("Name", "catagory already exist!");
                    return View(catagory);
                }

                _appDb.Catagories.Add(catagory);
                _appDb.SaveChanges();

                return RedirectToAction("Index");
            }
            public IActionResult Update(int id)
            {
                var wanted = _appDb.Catagories.FirstOrDefault(x => x.Id == id);
                if (wanted == null) return NotFound();
                return View(wanted);
            }
            [HttpPost]
            public IActionResult Update(Catagory catagory)
            {
                var exist = _appDb.Catagories.FirstOrDefault(x => x.Id == catagory.Id);
                if (exist == null) return NotFound();
                if (!ModelState.IsValid) return View(catagory);
                if (_appDb.Catagories.Any(x => x.Id != catagory.Id && x.Name.ToLower() == catagory.Name.ToLower()))
                {
                    ModelState.AddModelError("Name", "catagory already exist!");
                    return View(catagory);
                }
                exist.Name = catagory.Name;
                _appDb.SaveChanges();
                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                var wanted = _appDb.Catagories.FirstOrDefault(x => x.Id == id);
                if (wanted == null) return NotFound();
                return View(wanted);
            }
            [HttpPost]
            public IActionResult Delete(Catagory catagory)
            {
                var wanted = _appDb.Catagories.FirstOrDefault(x => x.Id == catagory.Id);
                if (wanted == null) return NotFound();
                _appDb.Catagories.Remove(wanted);
                _appDb.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

