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
    public class HomepageController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();
        // GET: Homepage
        public ActionResult Index()
        {
            var viewModel = new HomeVM();
            viewModel.Category = _repo.GetCategoryList();
            viewModel.Intimacy = (_repo.GetIntimacyList());
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
    }
}



    //    [HttpGet]
    //    public ActionResult CategoryList()
    //    {

<<<<<<< HEAD
        [HttpPost]
        public ActionResult CategoryList(HomeVM model)
        {
            HomeVM homeVM = new HomeVM();
            var selected = model.CategoryCheckboxes.Where(c => c.isSelected).Select(c => c.CategoryId);
            return View("CategoryList", homeVM);
=======
    //        var model = new HomeVM();
    //        model.CategoryCheckboxes = (from category in _repo.GetCategoryList()
    //                                    select new CategoryVM { Category = category, isSelected = false }).ToList();
>>>>>>> origin

    //        return View(model);
    //    }

    //    [HttpPost]
    //    public ActionResult CategoryList(HomeVM model)
    //    {

    //        var selected = model.CategoryCheckboxes.Where(c => c.isSelected).Select(c => c.Category.CategoryId);
    //        return View("CategoryList", selected);
    //    }
    //}
