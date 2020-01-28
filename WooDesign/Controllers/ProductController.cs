using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Models;

namespace WooDesign.Controllers
{
    public class ProductController : Controller
    {
        WooDesignDBEntities db = new WooDesignDBEntities();
        // GET: Product
 
        public ActionResult ProductDetails()
        {
            int geleneData = Convert.ToInt32(RouteData.Values["id"]);
            return View(db.Urunler.ToList().FirstOrDefault(k => k.UrunlerID == geleneData));
        }
    }
}