using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;
using Alkemy.App_Code;


namespace Alkemy.Controllers
{

    public class MateriasController : Controller
    {
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
                return RedirectToAction("Index", "Home"); 
            }
        }

        public ActionResult ListaMaterias()
        {

            
            List<Subjects> subjects = new List<Subjects>();
            using (AlkemyEntities db = new AlkemyEntities())
            {
                var lst = db.Subjects.ToList();
                return View(lst);
            }            
        }

        // GET: Materias/Details/5
        public ActionResult Detalle(int? id)
        {         
            List<Subjects> subjects = new List<Subjects>();
            List<Teachers> teachers = new List<Teachers>();

            using (AlkemyEntities db = new AlkemyEntities())
            {

                subjects = db.Subjects.ToList();
                teachers = db.Teachers.ToList();    

            var viewModel = new MateriaDetalleViewModel();
            var subject = subjects.Where(x => x.Id == id).FirstOrDefault();
            var teacher = teachers.Where(x => x.Id == subject.IdTeacher).FirstOrDefault();
            viewModel.Materia = subject.Subject_Name;
            viewModel.Profesor = teacher.Name_;
            viewModel.CupMax = subject.Quota_Max;
            viewModel.Horario = subject.Schedule;                   


                return View(viewModel);


            }           
        }
        public ActionResult Agregar()
        {

            List<Teachers> teachers = new List<Teachers>();
           
            using (AlkemyEntities db = new AlkemyEntities())
            {
                teachers = db.Teachers.ToList();

                List<SelectListItem> item = teachers.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Name_,
                    Value = a.Id.ToString(),
                    Selected = true
                };
            });
                ViewBag.Lista = new SelectList(item, "Value", "Text");
                return View();

            }
            
        }

        [Filters.AutorizeAdmin]
        [HttpPost]
        public ActionResult Agregar(Subjects model)
        {            

            List<Teachers> teachers = new List<Teachers>();

            if (!ModelState.IsValid)
                return View();

            using (AlkemyEntities db = new AlkemyEntities())
                    {
                        var oSubject = new Subjects();
                        oSubject.Subject_Name = model.Subject_Name;
                        oSubject.Quota_Max = model.Quota_Max;
                        oSubject.Schedule = model.Schedule;
                        oSubject.IdTeacher = model.IdTeacher;

                        db.Subjects.Add(model);
                        db.SaveChanges();

                        List<SelectListItem> item = teachers.ConvertAll(a =>
                        {
                            return new SelectListItem()
                            {
                                Text = a.Name_,
                                Value = a.Id.ToString(),
                                Selected = true
                            };
                        });
                        ViewBag.Lista = new SelectList(item, "Value", "Text");

                        int nuevo = db.Subjects.Max(x => x.Id) + 1;
                        oSubject.Id = nuevo;


                    }

                
                return Redirect("/Materias/ListaMaterias");
            
                    

        }
        
        public ActionResult Editar(int id) 
        {
            //Subjects model = new Subjects();
            List<Teachers> teachers = new List<Teachers>();
            List<Subjects> subjects = new List<Subjects>();

            using (AlkemyEntities db = new AlkemyEntities())
            {
                subjects = db.Subjects.ToList();
                teachers = db.Teachers.ToList();
                var viewModel = new Subjects();
                var subject = subjects.Where(x => x.Id == id).FirstOrDefault();
                //var teacher = teachers.Where(x => x.Id == subject.IdTeacher).FirstOrDefault();
                viewModel.Subject_Name = subject.Subject_Name;
                viewModel.IdTeacher = subject.IdTeacher;
                viewModel.Quota_Max = subject.Quota_Max;
                viewModel.Schedule = subject.Schedule;

                List<SelectListItem> item = teachers.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name_.ToString(),
                        Value = a.Id.ToString(),               
                    };
                });
                ViewBag.Lista = new SelectList(item, "Value", "Text");

                return View(subject);

            }
            

        }
        [Filters.AutorizeAdmin]
        [HttpPost]
        // GET: Profesores/Edit/5
        public ActionResult Editar(Subjects model)  //me falta esto
        {
            List<Subjects> subjects = new List<Subjects>();
            List<Teachers> teachers = new List<Teachers>();

            using (AlkemyEntities db = new AlkemyEntities())
            {
                subjects = db.Subjects.ToList();
                teachers = db.Teachers.ToList();               
                var subject = subjects.Where(x => x.Id == model.Id).FirstOrDefault();
                //var teacher = teachers.Where(x => x.Id == subject.IdTeacher).FirstOrDefault();
                subject.Subject_Name = model.Subject_Name;
                subject.IdTeacher = model.IdTeacher;
                subject.Quota_Max = model.Quota_Max;
                subject.Schedule = model.Schedule;

                List<SelectListItem> item = teachers.ConvertAll(a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name_.ToString(),
                        Value = a.Id.ToString(),                       
                    };
                });
                ViewBag.Lista = new SelectList(item, "Value", "Text");                
                db.SaveChanges();

            }

            return RedirectToAction("/ListaMaterias");
        }
        [Filters.AutorizeAdmin]
        [HttpGet]
        public ActionResult Eliminar(int id)
        {        
            using (AlkemyEntities db = new AlkemyEntities())
            {
                var delete = db.Subjects.Find(id);
                db.Subjects.Remove(delete);
                db.SaveChanges();
            }
            return Redirect("/Materias/ListaMaterias");
        }

      

    }
}
