using SCMS.Datas;
using SCMS.Models;
using SCMS.Models.Interface;
using SCMS.Models.ViewModels;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace SCMS.UI.Controllers
{
    public class StoryApprovalController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();
        // GET: StoryApproval
        [HttpGet]
        public ActionResult Index()
        {
            var model = _repo.GetStoryByStatus('P');
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewStory (int id)
        {
            Story model = _repo.GetStoryById(id);

            return View(model);
        }
        
        public ActionResult Approve(StoryVM story, string Save, string Denied)
        {
            if(!string.IsNullOrEmpty(Save))
            {
                _repo.ApproveStory(story.StoryId, story.Feedback);
            }
            else
            {
                _repo.DenyStory(story.StoryId, story.Feedback);
            }
            
            return RedirectToAction("Index");
        }
    }
}