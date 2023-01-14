using BE.U2_W2_D5.PS_GrandBudapestHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BE.U2_W2_D5.PS_GrandBudapestHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLog u)
        {
            if (UserLog.Autenticato(u.Username, u.Password))
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            return View();
        }

        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut(); 
            return Redirect(FormsAuthentication.DefaultUrl);
        }
        
    }
}