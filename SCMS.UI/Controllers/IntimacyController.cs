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
    public class IntimacyController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult List()
        {
            var model = _repo.GetIntimacyList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Intimacy());
        }

        [HttpPost]
        public ActionResult Add(Intimacy model)
        {
            _repo.AddIntimacy(model);
            return RedirectToAction("Intimacy");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editing = _repo.GetIntimacyById(id);
            return View(editing);
        }

        [HttpPost]
        public ActionResult Edit(Intimacy model)
        {
            //validate that list stays in the same place
            //id#1 when edit gets moved to the bottom of list
            var confirmEdit = _repo.UpdateIntimacy(model);
            return RedirectToAction("Intimacy");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleting = _repo.GetIntimacyById(id);
            return View(deleting);
        }

        [HttpPost]
        public ActionResult Delete(Intimacy model)
        {
            var confirmDelete = _repo.DeleteIntimacy(model.IntimacyId);
            return RedirectToAction("Intimacy");
        }
    }
}