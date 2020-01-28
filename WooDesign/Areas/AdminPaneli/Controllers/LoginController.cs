using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooDesign.Areas.AdminPaneli.Models;
using WooDesign.Models;

namespace WooDesign.Areas.AdminPaneli.Controllers
{
    public class LoginController : Controller
    {
        LoginManage log_mng = new LoginManage();
        // GET: AdminPaneli/Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIndex(string adi,string sifre)
        {
            var giris = log_mng.LoginIn(adi, sifre);
            if (giris!=null)
            {
                Session["adi"] = giris.UyeAdi;
                Session["email"] = giris.Email;
                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            ViewBag.mesaj = "Hatalı kullanıcı adı ya da şifre";
            return View();
              

        }
    }
}