using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class DefaultController : Controller
    {
        // GET: AdminPaneli/Default
        public ActionResult DefaultIndex()
        {
            return View();
        }
    }
}