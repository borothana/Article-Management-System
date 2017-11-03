using SCMS.Datas;
using SCMS.Models;
using SCMS.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMS.UI.Controllers
{
    public class CategoryController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult List()
        {
            var model = _repo.GetCategoryList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (string.IsNullOrEmpty(category.Description))
            {
                ModelState.AddModelError("Category", "Description is required");
            }

            if(_repo.AddCategory(category) > 0)
            {
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("Category", "Cannot add category");
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category model = _repo.GetCategoryById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError("Category", "Description is required");
            }

            if(_repo.UpdateCategory(model))
            {
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("Category", "Cannot edit category");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category model = _repo.GetCategoryById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Category model)
        {
            if (_repo.DeleteCategory(model.CategoryId))
            {
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("Category", "Cannot delete category");
                return View(model);
            }
            
        }
    }
}