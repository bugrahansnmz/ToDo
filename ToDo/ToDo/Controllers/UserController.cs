using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ToDo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(int id)
        {
            var userID = HttpContext.Session.GetInt32("UserID");
            var userName = HttpContext.Session.GetString("UserName");
            ViewData["userID"] = userID;
            ViewData["userName"] = userName;
            var users = _userService.Get(userID);
            return View(users);
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            _userService.Update(user);
            ViewData["userName"] = user.UserName;
            return View();
        }
       
    }
}
