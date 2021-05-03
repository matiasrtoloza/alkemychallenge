using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;
using Alkemy.App_Code;

namespace Alkemy.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {
            return View();
        }
        // GET: Profesores/Lista
        public ActionResult Lista()
        {
            List<Teachers> teachers = new List<Teachers>();
            using (AlkemyEntities db = new AlkemyEntities())
            {
                var lst = db.Teachers.ToList();
                return View(lst);
            }
        }

        // GET: Profesores/Details/5
        public ActionResult Detalle(int? id)
        {
            List<Teachers> teachers = new List<Teachers>();
            using (AlkemyEntities db = new AlkemyEntities())
            {

                teachers = db.Teachers.ToList();
                var teacher = teachers.Where(x => x.Id == id).FirstOrDefault();
            
            return View(teacher);
            }
        }

        // GET: Profesores/Create
        public ActionResult Agregar()
        {
            List<Teachers> teachers = new List<Teachers>();

            using (AlkemyEntities db = new AlkemyEntities())
            {
                teachers = db.Teachers.ToList();
            }
                return View();
        }
        [HttpPost]
        public ActionResult Agregar(Teachers model)
        {
            if (!ModelState.IsValid)
                return View();

            List<Teachers> teachers = new List<Teachers>();     
            using (AlkemyEntities db = new AlkemyEntities())
            {
                teachers = db.Teachers.ToList();

                var oTeacher = new Teachers();

                db.Teachers.Add(model);
                db.SaveChanges();        

                int nuevo = db.Teachers.Max(x => x.Id) + 1;
                oTeacher.Id = nuevo;
            }
                return Redirect("/Profesores/Lista");
        }

        public ActionResult Editar(int Id)
        {
            List<Teachers> teachers = new List<Teachers>();
            using (AlkemyEntities db = new AlkemyEntities())
            {
                teachers = db.Teachers.ToList();
                var teacher = teachers.Where(x => x.Id == Id).FirstOrDefault();
                return View(teacher);
            }
        }

        [HttpPost]
        // GET: Profesores/Edit/5
        public ActionResult Editar(Teachers model)
        {
            List<Teachers> teachers = new List<Teachers>();
            using (AlkemyEntities db = new AlkemyEntities())
            {
                teachers = db.Teachers.ToList();
                var teacher = teachers.Where(x => x.Id == model.Id).FirstOrDefault();                
                teacher.Name_ = model.Name_;
                teacher.Identification = model.Identification;
                teacher.Id = model.Id;                
                db.SaveChanges();

                return RedirectToAction("Lista");
            }
        }

        
        public ActionResult Eliminar(int? id) 
        {
            
            using (AlkemyEntities db = new AlkemyEntities())
            {
                var delete = db.Teachers.Find(id);
                db.Teachers.Remove(delete);
                db.SaveChanges();                
            }
            
            return Redirect("/Profesores/Lista");            
        }
    }
}
