using Microsoft.AspNetCore.Mvc;
using Module20.DataBase;
using Module20.Logic.Commands;
using Module20.Logic.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module20.Controllers
{
    public class HomeController : Controller
    {
        private UserDb db;
        public IActionResult Index()
        {
            return View(Query.GetUsersToList());
        }
        [HttpGet]
        public IActionResult User(int value)
        {
            DataStaticClass.Value = value; //Set id in static class for further work
            db = new UserDb(); 
            User user = db.Users.Where(user => user.Id == value).First(); //Search person by id
            return View(user);  //Set person for work
        }
        public IActionResult RemoveUser()
        {
            User user = db.Users.Where(user => user.Id == DataStaticClass.Value).First(); //Search person by id from static class
            Commands.RemoveUserAsync(user);
            return Redirect("/Home/Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
                Commands.UpdateUserAsync(user);

            return Redirect("/Home/Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
                Commands.AddAsync(user);

            return Redirect("/Home/Index");
        }
    }
}
