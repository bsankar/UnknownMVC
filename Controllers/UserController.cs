using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnknownMVC.Models;
namespace UnknownMVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private TasksDB tasks;
        public UserController()
        {
            if (tasks == null)
                tasks = new TasksDB();
        }
        public ActionResult Index()
        {
            
            var k = from t in tasks.Users
                    select t;
            var m= k.ToList<User>();
            return View("Index",m);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var usr = new User { UserName = collection["UserName"] };
                tasks.Users.Add(usr);
                tasks.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index",null);
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
