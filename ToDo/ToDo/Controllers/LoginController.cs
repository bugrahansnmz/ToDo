using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDo.Controllers
{
    public class LoginController : Controller
    {
        IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            int isLogin = _userService.GetUserLogin(user.Email, user.Password);
            if (isLogin > 0)
            {
                User currentUser = _userService.Get(isLogin);
                ViewData["userName"] = currentUser.UserName + " " + currentUser.Surname;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                HttpContext.Session.Clear();
                var userID = HttpContext.Session.Get("UserID");
                if (userID == null)
                {
                    HttpContext.Session.SetInt32("UserID", currentUser.UserID);
                    HttpContext.Session.SetString("UserName", currentUser.UserName);
                }
                return RedirectToAction("Index", "ToDo");
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(User user)
        {
            _userService.Add(user);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
