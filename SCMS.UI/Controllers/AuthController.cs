using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models;
using SCMS.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SCMS.Datas;
using SCMS.Models.Interface;

namespace SCMS.UI.Controllers
{
    public class AuthController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        public ActionResult Login()
        {
            var model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Login(model.UserName, model.Password).Result)
                {
                    if (String.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(Url.Action("Home", "Home"));
                    }
                }
                else
                {
                    ModelState.AddModelError("Auth", "Incorrect email or password, please try again.");
                }
            }
            return View(model);

        }
    }
}