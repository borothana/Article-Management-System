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
    public class InfoController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult List()
        {
            var model = _repo.GetInfoList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Info());
        }

        [HttpPost]
        public ActionResult Add(Info model)
        {
            if (ModelState.IsValid)
            {
                if (model.FDate > model.TDate)
                {
                    ModelState.AddModelError("Info", "Display start date must be greater than end date");
                }
                else
                {
                    if (_repo.AddInfo(model) > 0)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("Info", "Cannot add new information");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int infoId)
        {
            Info model = _repo.GetInfoById(infoId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Info model)
        {
            if (ModelState.IsValid)
            {
                if (model.FDate > model.TDate)
                {
                    ModelState.AddModelError("Info", "Display start date must be greater than end date");
                }
                else
                {
                    if (_repo.UpdateInfo(model))
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("Info", "Cannot edit new information");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int infoId)
        {
            Info model = _repo.GetInfoById(infoId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Info model)
        {
            if (_repo.DeleteInfo(model.InfoId))
            {
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("Info", "Cannot delete new information");
            }
            return View(model);
        }
    }
}