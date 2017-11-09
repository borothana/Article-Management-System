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
                string id = _repo.AddUser(model, Role.member.ToString());
                if (!string.IsNullOrEmpty(id))
                {
                    _repo.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }                
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            UserVMEdit model = _repo.GetUserVMEditById(CurrentUser.User.Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserVMEdit model)
        {
            if (ModelState.IsValid)
            {                
                if (_repo.UpdateUser(model, Role.member.ToString()))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}