using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoInicioSesionMVC.Models;
using ProyectoInicioSesionMVC.Models.TableViewModels;
using ProyectoInicioSesionMVC.Models.ViewModel;

namespace ProyectoInicioSesionMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;

            using(ProyectoInicioSesionMVCEntities db = new ProyectoInicioSesionMVCEntities())
            {
                lst = (from d in db.Users
                       where d.idState == 1
                       orderby d.Email
                       select new UserTableViewModel
                       {
                           Id = d.Id,
                           Email = d.Email,
                           Edad = d.Edad
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ProyectoInicioSesionMVCEntities())
            {
                Users oUser = new Users();
                oUser.idState = 1;
                oUser.Email = model.Email;
                oUser.Password = model.Password;
                oUser.Edad = model.Edad;

                db.Users.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new ProyectoInicioSesionMVCEntities())
            {
                var oUser = db.Users.Find(Id);
                model.Email = oUser.Email;
                model.Edad = (int)oUser.Edad;
                model.Id = oUser.Id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ProyectoInicioSesionMVCEntities())
            {
                var oUser = db.Users.Find(model.Id);
                oUser.Email = model.Email;
                oUser.Edad = model.Edad;

                if ( model.Password != null && model.Password.Trim() != "")
                {
                    oUser.Password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
        
        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new ProyectoInicioSesionMVCEntities())
            {
                var oUser = db.Users.Find(Id);
                oUser.idState = 3; //Eliminado

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}