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
        public ActionResult List()
        {
            List<Story> model = _repo.GetStoryByUser(CurrentUser.User.Id);
            return View(model);
        }

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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Story", "Cannot add new story");
                }
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int storyId)
        {
            StoryVM model = _repo.GetStoryVMById(storyId);
            model.SetCategoryItems(_repo.GetCategoryList());
            model.SetIntimacyItems(_repo.GetIntimacyList());
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StoryVM model)
        {
            if (ModelState.IsValid)
            {
                if (_repo.UpdateStory(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Story", "Cannot edit story");
                }
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Delete(int storyId)
        {
            StoryVM model = _repo.GetStoryVMById(storyId);
            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(StoryVM model)
        {
            if (_repo.DeleteStory(model.StoryId))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Story", "Cannot delete story");
                return View(model);
            }
        }
    }
}