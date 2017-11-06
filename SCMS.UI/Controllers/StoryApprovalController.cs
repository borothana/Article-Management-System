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
    public class StoryApprovalController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();
        // GET: StoryApproval
        [HttpGet]
        public ActionResult Index()
        {
            var model = _repo.GetStoryList();
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewStory (int id)
        {
            Story model = _repo.GetStoryById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult ViewStory (Story story)
        {
            throw new Exception();
        }
    }
}