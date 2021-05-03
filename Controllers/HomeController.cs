using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;

namespace Alkemy.Controllers
{

    public class HomeController : Controller
    {
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
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(TBL_User_Info tBL_User_Info)
        {
            if (db.TBL_User_Info.Any(x => x.UsernameUs == tBL_User_Info.UsernameUs))
            {
                ViewBag.Notificacion = "Esta cuenta ya existe";
                return View();
            }
            else
            {
                db.TBL_User_Info.Add(tBL_User_Info);
                db.SaveChanges();

                Session["IdUsSS"] = tBL_User_Info.IdUs.ToString();
                Session["UsernameSS"] = tBL_User_Info.UsernameUs.ToString();
                Session["C_Roles"] = tBL_User_Info.C_Roles;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TBL_User_Info tBL_User_Info, string username, string password)
        {

            var checkLogin = db.TBL_User_Info.Where(x => x.UsernameUs.Equals(tBL_User_Info.UsernameUs) && x.PasswordUs.Equals(tBL_User_Info.PasswordUs) && x.C_Roles.Equals(tBL_User_Info.C_Roles)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdUsSS"] = tBL_User_Info.IdUs.ToString();
                Session["C_Roles"] = tBL_User_Info.C_Roles;
                Session["UsernameSS"] = tBL_User_Info.UsernameUs.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "El usuario o la contraseña esta mal ";
            }
            return View();




            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}