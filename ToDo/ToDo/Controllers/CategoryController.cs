using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ToDo.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var userID = HttpContext.Session.GetInt32("UserID");
            var userName = HttpContext.Session.GetString("UserName");
            ViewData["userID"] = userID;
            ViewData["userName"] = userName;
            var categories = _categoryService.GetAll(userID);
            return View(categories);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var category = _categoryService.Get(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                if (HttpContext.Session.GetInt32("UserID") != null)
                {
                    category.UserID = HttpContext.Session.GetInt32("UserID");
                    _categoryService.Add(category);
                }
            }
            else
            {
                _categoryService.Update(category);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
