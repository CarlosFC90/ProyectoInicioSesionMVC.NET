using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoInicioSesionMVC.Models;

namespace ProyectoInicioSesionMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (ProyectoInicioSesionMVCEntities db = new ProyectoInicioSesionMVCEntities())
                {
                    var lst = from d in db.Users
                              where d.Email == user && d.Password == password && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        Users oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("User not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("We have a problem :( " + ex.Message);
            }
        }
    }
}