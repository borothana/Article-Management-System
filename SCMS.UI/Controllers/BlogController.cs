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
    public class BlogController : Controller
    {
        ISCMS _repo = SCMSFactory.Create();

        // GET: Blog
        public ActionResult Blog()
        {
            BlogVM blogVM = new BlogVM();
            blogVM.Blog = _repo.GetBlogList();
            blogVM.Category = _repo.GetCategoryList();
            blogVM.Intimacy = _repo.GetIntimacyList();
            blogVM.Story = _repo.GetStoryList();
            blogVM.User = _repo.GetUserList();

            return View(blogVM);
        }
    }
}