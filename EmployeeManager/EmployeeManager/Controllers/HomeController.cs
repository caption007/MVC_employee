using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeManagerContext _context;

        public HomeController(EmployeeManagerContext context)
        {
            _context = context;
        }

        // GET: Home
        public IActionResult Login(string Name,string Pwd)
        {
            
            if ((Name != null&&Name=="admin") &&(Pwd != null && Pwd == "admin"))
            {
                HttpContext.Session.SetString("user",Name);     //记录是否登录      
                return RedirectToAction("Index", "Employees");   
            }
            else
            {
                ViewBag.Error = "用户名或密码不正确！";
            }
            return View();
        }

        public ActionResult LogOff()
        {
            return RedirectToAction("Login","Home");
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
