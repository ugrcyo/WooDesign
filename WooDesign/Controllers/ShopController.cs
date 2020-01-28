using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using WooDesign.Models;

namespace WooDesign.Controllers
{
    public class ShopController : Controller
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        // GET: Shop
        public ActionResult ShopIndex()
        {
            return View(db.Urunler.ToList());
        }
    }
}