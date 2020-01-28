using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Models;


namespace WooDesign.Controllers
{
    public class SiteIndexController : Controller
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        // GET: SiteIndex
        public ActionResult TestIndex()
        {
            return View();
        }
        public ActionResult SiteIndex()
        {
            return View(db.Urunler.ToList());
        }
    }
}