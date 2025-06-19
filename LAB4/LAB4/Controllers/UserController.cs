using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LAB3.Controllers
{
    public class UserController : Controller
    {
        static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    users.Add(user);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(user);
        }

        public IActionResult Index()
        {
            return View(users);
        }
    }
}
