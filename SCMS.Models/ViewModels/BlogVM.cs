using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCMS.Models.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Intimacy> Intimacy { get; set; }
        public IEnumerable<Story> Story { get; set; }


        public List<SelectListItem> UserItems { get; set; }
        public List<SelectListItem> BlogItems { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> IntimacyItems { get; set; }
        public List<SelectListItem> StoryItems { get; set; }

        public BlogVM()
        {
            UserItems = new List<SelectListItem>();
            BlogItems = new List<SelectListItem>();
            CategoryItems = new List<SelectListItem>();
            IntimacyItems = new List<SelectListItem>();
            StoryItems = new List<SelectListItem>();
        }

        public void SetUserItems(IEnumerable<User> users)
        {
            UserItems = new List<SelectListItem>();
            foreach (var user in users)
            {
                UserItems.Add(new SelectListItem()
                {
                    Value = user.Id,
                    Text = user.Nickname
                });
            }
        }
        public void SetBlogItems(IEnumerable<Blog> blogs)
        {
            BlogItems = new List<SelectListItem>();
            foreach (var blog in blogs)
            {
                BlogItems.Add(new SelectListItem()
                {
                    Value = blog.BlogId.ToString(),
                    Text = blog.Title
                });
            }
        }
    }
}
