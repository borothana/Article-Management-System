using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models.ViewModels;
using SCMS.Models.Interface;
using SCMS.Datas;

namespace SCMS.UI.Controllers
{
    public class ResetPasswordController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        // GET: ResetPassword
        public ActionResult ResetPassword()
        {
            ResetPasswordVM model = new ResetPasswordVM();
            model.UserName = CurrentUser.User.UserName;
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid || model.NewPassword != model.NewPasswordRetype)
            {
                return View(model);
            }
            _repo.ChangePassword(model.UserName, model.Password, model.NewPassword);
            return RedirectToAction("Index","Home");
        }
    }
}