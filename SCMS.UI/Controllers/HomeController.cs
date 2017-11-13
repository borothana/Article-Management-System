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
            HomeVM viewModel = new HomeVM();
            viewModel.Category = _repo.GetCategoryList();
            viewModel.Intimacy = _repo.GetIntimacyList();
            viewModel.Story = _repo.GetStoryList();
            viewModel.User = _repo.GetUserList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeVM model)
        {
            HomeVM viewModel = new HomeVM();
            viewModel.Category = _repo.GetCategoryList();
            viewModel.Intimacy = _repo.GetIntimacyList();
            viewModel.Story = _repo.GetStoryList();
            viewModel.User = _repo.GetUserList();

            return View(viewModel);
        }

        public ActionResult CategoryList(int id)
        {
            var viewModel = new HomeVM();
            viewModel.Category = _repo.GetCategoryList().Where(c => c.CategoryId == id);
            viewModel.Intimacy = _repo.GetIntimacyList().Where(i => i.IntimacyId == id);
            return View(viewModel);
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