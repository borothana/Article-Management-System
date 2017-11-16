using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models.ViewModels;
using SCMS.Models.Interface;
using SCMS.Models;
using SCMS.Datas;

namespace SCMS.UI.Controllers
{

    public class ProfileController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public ActionResult SignUp(UserVM model)
        {
            if (ModelState.IsValid)
            {               
                if (_repo.AddUser(model, Role.member.ToString()).Result.Success)
                {
                    _repo.Login(model.UserName, model.ConfirmPassword);
                    return RedirectToAction("Index", "Home");
                }                
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "member")]
        public ActionResult Edit()
        {
            UserVM model = _repo.GetUserVMByUserName(CurrentUser.User.UserName);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "member")]
        public ActionResult Edit(UserVM model)
        {
            ModelState.Remove("PasswordHash");
            ModelState.Remove("UserName");
            if (ModelState.IsValid)
            {                
                if (_repo.UpdateUser(model, Role.member.ToString()).Result.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}