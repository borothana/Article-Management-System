using SCMS.Datas;
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
            model.Category = _repo.GetCategoryList();
            model.Intimacy = _repo.GetIntimacyList();
            model.Story = _repo.GetStoryList();
            model.User = _repo.GetUserList();

            //Example
            //model.Story = _repo.GetStoryForHome(new List<int>() { 1, 2, 3, 4, 5 }, new List<int>() { 1, 2, 3, 4, 5 }, "", "#love #newlife");
            model.Story = _repo.GetStoryForHome(new List<int>(), new List<int>(), "", "");

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeVM model)
        {
            model.Category = _repo.GetCategoryList();
            model.Intimacy = _repo.GetIntimacyList();
            model.Story = _repo.GetStoryList();
            model.User = _repo.GetUserList();
            model.Story = _repo.GetStoryForHome(model.CategoryIdSearch, model.IntimacyIdSearch, model.TitleSearch, model.HashtagSearch);

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