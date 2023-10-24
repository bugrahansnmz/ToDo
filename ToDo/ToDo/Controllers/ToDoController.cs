using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        ICategoryService _categoriaService;
        IToDoService _toDoService;
        public ToDoController(IToDoService toDoService, ICategoryService categoryService)
        {
            _toDoService = toDoService;
            _categoriaService = categoryService;
        }
        public IActionResult Index(string search)
        {
            var userID = HttpContext.Session.GetInt32("UserID");
            var userName = HttpContext.Session.GetString("UserName");
            ViewData["userID"] = userID;
            ViewData["userName"] = userName;
            if (!string.IsNullOrEmpty(search))
            {
                var searchTodo = _toDoService.GetAllTodos(search,userID).OrderBy(x=>x.PriorityLevel);
                return View(searchTodo);
            }
            var todos = _toDoService.GetAll(userID).OrderBy(x => x.PriorityLevel);
            return View(todos);
        }
        [HttpGet]
        public IActionResult UpdateOrAddToDo(int id)
        {
            var userID = HttpContext.Session.GetInt32("UserID");
            List<SelectListItem> categoryList = (from cat in _categoriaService.GetAll(userID)
                                                 select new SelectListItem
                                                 {
                                                     Text = cat.CategoryName,
                                                     Value = cat.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.catList = categoryList;
            if (id == 0)
            {
                return View();
            }
            var todo = _toDoService.Get(id);
            return View(todo);
        }
        [HttpPost]
        public IActionResult UpdateOrAddToDo(Entities.Concrete.ToDo toDo)
        {
            if (toDo.TodoID == 0)
            {
                toDo.Status = true;
                toDo.CreationDate = DateTime.Now;
                toDo.IsComplated = false;
                toDo.UserID = HttpContext.Session.GetInt32("UserID");
                _toDoService.Add(toDo);
            }
            else
            {
                _toDoService.Update(toDo);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteToDo(int id)
        {
            var toDo = _toDoService.Get(id);
            _toDoService.Delete(toDo);
            return RedirectToAction("Index");
        }
    }
}
