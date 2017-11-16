using SCMS.Datas;
using SCMS.Models;
using SCMS.Models.Interface;
using SCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.UI.Controllers
{
    public class HomeController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();
        // GET: Homepage
        public ActionResult Index()
        {
            HomeVM model = new HomeVM();

            model.CategoryVM = _repo.GetCategoryVMList();
            model.IntimacyVM = _repo.GetIntimacyVMList();
            model.SetCategoryItems(_repo.GetCategoryList());
            model.SetIntimacyItems(_repo.GetIntimacyList());
            model.User = _repo.GetUserList();

            //Example
            //model.Story = _repo.GetStoryForHome(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, "", "#love #newlife");
            model.StoryVM = _repo.GetStoryForHome(new List<int>(), new List<int>(), "", "", "");

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeVM model)
        {
            model.CategoryIdSearch = new List<int>();
            foreach(var c in model.CategoryVM)
            {
                if (c.IsSelected)
                {
                    model.CategoryIdSearch.Add(c.Category.CategoryId);
                }
            }

            model.IntimacyIdSearch = new List<int>();
            foreach (var c in model.IntimacyVM)
            {
                if (c.IsSelected)
                {
                    model.IntimacyIdSearch.Add(c.Intimacy.IntimacyId);
                }
            }

            model.CategoryVM = _repo.GetCategoryVMList();
            model.IntimacyVM = _repo.GetIntimacyVMList();
            model.SetCategoryItems(_repo.GetCategoryList());
            model.SetIntimacyItems(_repo.GetIntimacyList());
            model.User = _repo.GetUserList();
            model.StoryVM = _repo.GetStoryForHome(model.CategoryIdSearch, model.IntimacyIdSearch, model.UserNameSearch + "", model.TitleSearch + "", model.HashtagSearch + "");

            return View(model);
        }
        [HttpGet]
        public ActionResult StoryPage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;
            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Auth");

            //return View();
        }
    }
}