using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakipFormu.Models;

namespace UrunTakipFormu.Controllers
{
    public class PersonelUrunBilgiController : Controller
    {
       
        public ActionResult Index()
        {
            LoginControl loginControl = LoginControl.GetInstance();
            if (loginControl.IsAdmin == true)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //ViewBag.IsAdmin = true;
            //ViewBag.IsLogin = true;

        }
    }
}