using Antlr.Runtime.Tree;
using AppBhirtday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBhirtday.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Index()
        { 
            return View();
        }
        
        public ActionResult DavetiyeFormu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DavetiyeFormu(Davetiye model)
        {

            if (ModelState.IsValid)
            {
                Veritabani.Add(model);
                return View("Thanks", model);
            }
            return View(model);
        }

        public ActionResult Katilanlar()
        {
            var katilanlar = (Veritabani.Liste.Where(c => c.KatilmeDurumu == true)); 
            return PartialView(katilanlar);
        }
    }
}