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
            model.Result = _repo.ReturnSuccess();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            model.Result = _repo.ReturnSuccess();
            if (ModelState.IsValid)
            {
                if (_repo.Login(model.UserName, model.PasswordHash))
                {
                    return Redirect(Url.Action("Index", "Home"));

                }
                else
                {
                    ModelState.AddModelError("Auth", "Incorrect username or password!");
                    model.Result.ErrorMessage = "Incorrect username or password!";
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            _repo.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}