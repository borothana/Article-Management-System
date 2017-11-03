using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;
            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Login","Auth");

            //return View();
        }
    }
}