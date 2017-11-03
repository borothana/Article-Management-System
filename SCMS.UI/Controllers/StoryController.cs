using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.Models;
using SCMS.Datas;
using SCMS.Models.Interface;
using SCMS.Models.ViewModels;

namespace SCMS.UI.Controllers
{
    public class StoryController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult Add()
        {
            StoryVM model = new StoryVM();
            model.UserId = CurrentUser.User.Id;
            model.SetCategoryItems(_repo.GetCategoryList());
            model.SetIntimacyItems(_repo.GetIntimacyList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(StoryVM model)
        {
            if (ModelState.IsValid)
            {
                if (_repo.AddStory(model) > 0)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("Story", "Cannot add new story");
                }
            }
            return View(model);
        }
    }
}