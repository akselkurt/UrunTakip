using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrunTakip.Core.Repository;
using UrunTakipFormu.Models;

namespace UrunTakipFormu.Controllers
{
    

    public class CustomerProductInfoController : Controller
    {
        // GET: CustomerProductInfo
        private ITransaction transactionRepo;
        public CustomerProductInfoController(ITransaction transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }
        public CustomerProductInfoController()
        {

        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetProductAsync(string receteNo)
        {
            try
            {
                if (receteNo != "" && receteNo!=null )
                {
                    var getProductAsync = await transactionRepo.GetProductAsync(receteNo);
                    UrunBilgiInput UrunBilgiInput = new UrunBilgiInput
                    {
                        QName = getProductAsync.FirstOrDefault().QName,
                        Date = getProductAsync.FirstOrDefault().Date,
                        EndProcessingDate = getProductAsync.FirstOrDefault().EndProcessingDate,
                        Processing = getProductAsync.FirstOrDefault().Processing
                    };
                    return Json(UrunBilgiInput, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(new {message="Bilgiler getirilemedi" },JsonRequestBehavior.AllowGet);
                }
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new {message= "CustomerProductInfo" },JsonRequestBehavior.AllowGet);
            }
        }
    }
}