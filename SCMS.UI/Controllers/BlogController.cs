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
    public class BlogController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        [HttpGet]
        public ActionResult Blog()
        {
            List<Info> model = _repo.GetCurrentInfo();            
            return View(model);
        }
    }
}