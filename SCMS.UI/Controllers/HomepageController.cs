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
            return View();
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


        [HttpGet]
        public ActionResult CategoryList()
        {

            return View(_repo.GetCategoryList());
        }

        [HttpPost]
        public ActionResult CategoryList(CategoryPickerVM model)
        {
            CategoryPickerVM categoryVM = new CategoryPickerVM();
            var selected = model.CategoryCheckboxes.Where(c => c.isSelected).Select(c => c.CategoryId);
            return View("CategoryList", categoryVM);

            //var filtered = model.isSelectedWhere(c => c.IsSelected).ToList();
            //return RedirectToAction("Category");
        }
    }
}