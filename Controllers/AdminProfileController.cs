using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;

namespace Alkemy.Controllers
{
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile
        public ActionResult Index()
        {
            return View();
        }
        [Filters.AutorizeAdmin]
        public ActionResult UserList()
        {
            return View(db.TBL_User_Info.ToList());
        }
        DBUserSignupLoginEntities2 db = new DBUserSignupLoginEntities2();

        // GET: AdminProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProfile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminProfile/Edit/5
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

        // GET: AdminProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminProfile/Delete/5
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
