﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnknownMVC.Models;
namespace UnknownMVC.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        private TasksDB tsks;
        public TaskController()
        {
            if(tsks==null)
            {
                tsks = new TasksDB();
            }
        }
        public ActionResult Index()
        {
            var k=(from p in tsks.Tasks select p).ToList<Task>();
            return View("Index",k);
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var m = new Task { TaskUser = new User { UserID=1 }, TaskDescription = collection["TaskDescription"].ToString(), TaskCreated=DateTime.Now };
                tsks.Tasks.Add(m);
                tsks.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult MobileCreate(Task tsk)
        {
            String status = "";
            try
            {
                // TODO: Add insert logic here
                var m = new Task { TaskUser = tsk.TaskUser, TaskDescription = tsk.TaskDescription.ToString(), TaskCreated = DateTime.Now };
                tsks.Tasks.Add(m);
                tsks.SaveChanges();
                status = "Success";
            }
            catch
            {
                status="Failure";
            }

            return Json(status);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Task/Edit/5


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
        // GET: /Task/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5

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
