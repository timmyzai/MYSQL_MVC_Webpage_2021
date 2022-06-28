using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MVC_Project2021.Data;
using MVC_Project2021.Models;
using System.Linq;

namespace MVC_Project2021.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Username")
            {
                return View(_db.User.Where(x => x.Username.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Fullname")
            {
                return View(_db.User.Where(x => x.Fullname.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(_db.User.Where(x => x.Email.Contains(search) || search == null).ToList());
            }
        }

        //Get - Create
        public IActionResult Signup()
        {

            return View();
        }
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignupPost(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.User.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.User.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get - EditPassword
        public IActionResult EditPassword(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.User.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - EditPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPasswordPost(User obj)
        {
                if (ModelState.IsValid)
                {
                    _db.User.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(obj);
        }
    }
}
