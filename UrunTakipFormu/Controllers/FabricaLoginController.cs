using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using UrunTakip.Core.Repository;
using UrunTakipFormu.Models;

namespace UrunTakipFormu.Controllers
{
    public class FabricaLoginController : Controller
    {
        private IUserRepository userRepository;

        public FabricaLoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        

     
        LoginControl loginControl = LoginControl.GetInstance();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(string UserName, string password)
        {
 
            if (ModelState.IsValid)
            {
                object[] LoginStatus = await userRepository.UserLogin(UserName, password);
                if (LoginStatus != null)
                {
                    FormsAuthentication.SetAuthCookie(UserName, false);
                    if (object.Equals(LoginStatus[2], (object)1)) //rol id si 1 ise 
                    {
                        loginControl.IsAdmin = true;
                        loginControl.IsLogin = true;
                        loginControl.UserID = LoginStatus[1];
                        loginControl.FullName = LoginStatus[0];
                        return RedirectToAction("Index","PersonelUrunBilgi");
                    }
                    else if (object.Equals(LoginStatus[2], (object)2)) // rol id si 2 ise 
                    {
                        loginControl.IsAdmin = false;
                        loginControl.IsLogin = true;
                        loginControl.UserID = LoginStatus[1];
                        loginControl.FullName = LoginStatus[0];
                        return RedirectToAction("Index","CustomerProductInfo");
                    }
                    else
                    {

                        TempData["UserLoginFailed"] = "Giriş başarısız!";
                        return View("Index");
                    }

                }
                else
                {
                    TempData["UserLoginFailed"] = "Giriş başarısız!Lütfen doğru kimlik bilgilerinizi giriniz.";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
           
        }

    }
}


