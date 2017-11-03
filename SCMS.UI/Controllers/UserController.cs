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
    public class UserController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();


        public ActionResult List()
        {
            List<User> model = _repo.GetUserListByRole("admin");
            return View(model);
        }

        public ActionResult Add()
        {
            User model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.IsActive = true;
            if( _repo.AddUser(model, "admin") != "")
            {
                return RedirectToAction("List");
            }
            return View(model);            
        }

        [HttpGet]
        public ActionResult Edit(string userName)
        {
            User user = _repo.GetUserByUserName(userName);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (model.IsActive == true)
            {
                _repo.DeactivateUser(model.UserName);
            }
            else{
                _repo.ReactivateUser(model.UserName);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(string userName)
        {
            User user = _repo.GetUserByUserName(userName);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User model)
        {
            _repo.DeleteUser(model.Id);
            return RedirectToAction("List"); 
        }
    }
}