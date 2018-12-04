﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using UrunTakip.Core.Models;
using UrunTakip.Core.Repository;
using UrunTakipFormu.Models;

namespace UrunTakipFormu.Controllers
{
    public class HomeController : Controller
    {
        private ITransaction transactionRepo;
        public HomeController(ITransaction transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }

        public HomeController()
        { }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
     
        public ActionResult CustomerSampleFollowIndex()
        {
            return View();
          
        }
        [HttpPost]
        public ActionResult SampleIndex(UrunBilgiInput bilgi)
        {
            try
            {
                SaveToDatabase(GetUrunBilgi(bilgi));
                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bilgi);
            }
           
        }
        private async void SaveToDatabase(UrunBilgi bilgi)
        {
            ProductsInfo productInfo = new ProductsInfo { 
                Amount= bilgi.Amount,
                Chemical=bilgi.Chemical,
                ChemicalProduct=bilgi.ChemicalProduct,
                Color=bilgi.Color,
                CustomerName=bilgi.CustomerName,
                Date=bilgi.Date,
                Date2=bilgi.Date2,
                DateOfProcessing=bilgi.DateOfProcessing,
                EndProcessingDate=bilgi.EndProcessingDate,
                Id=bilgi.Id,
                Manager=bilgi.Manager,
                Processing=bilgi.Processing,
                QName=bilgi.QName,
                Txt1=bilgi.Txt1
            };
            var productInfoList = new List<ProductsInfo>();
            productInfoList.Add(productInfo);
            var repositoryResult = await transactionRepo.SaveProductAsync(productInfoList);
        }
        private UrunBilgi GetUrunBilgi(UrunBilgiInput bilgi)
        {
            UrunBilgi urun = new UrunBilgi();
            urun.QName = bilgi.QName; // reçeteNo
            urun.Date = bilgi.Date;
            urun.CustomerName = bilgi.CustomerName;
            urun.Amount = bilgi.Amount;
            urun.Color = bilgi.Color;
            urun.Chemical = bilgi.Chemical;
            urun.ChemicalProduct = bilgi.ChemicalProduct;
            urun.Txt1 = bilgi.Txt1;
            urun.Processing = bilgi.Processing;
            urun.DateOfProcessing = bilgi.DateOfProcessing;
            urun.EndProcessingDate = bilgi.EndProcessingDate;
            urun.Date2 = bilgi.Date2;
            urun.Manager = bilgi.Manager;

            return urun;

        }
        public ActionResult CustomerIndex()
        {
            return View();
        }
       
    }
}