using DotNetWebApplication.DataAccess.Data;
using DotNetWebApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace DotNetWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objcategoryList = _db.Categories.ToList();
            return View(objcategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (string.IsNullOrEmpty(obj.Name))
            {
                ModelState.AddModelError("Name", "Enter the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? objcategory = _db.Categories.Find(Id);
            if (objcategory == null)
            {
                return NotFound();
            }

            return View(objcategory);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? objcategory = _db.Categories.Find(Id);
            return View(objcategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category? objcategory = _db.Categories.Find(Id);

            if (objcategory == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(objcategory);
            _db.SaveChanges();

            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}