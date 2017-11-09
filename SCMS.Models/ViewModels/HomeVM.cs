using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCMS.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Intimacy> Intimacy { get; set; }
        public IEnumerable<Story> Story { get; set; }
        public IEnumerable<User> User { get; set; }


        public StoryVM StoryVM { get; set; }
        public UserVM UserVM { get; set; }
        public CategoryVM CategoryVM {get;set;}
        public IntimacyVM IntimacyVM { get; set; }
        

        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> IntimacyItems { get; set; }
        public List<SelectListItem> StoryItems { get; set; }
        public List<SelectListItem> UserItems { get; set; }

        public HomeVM()
        {
            CategoryItems = new List<SelectListItem>();
            IntimacyItems = new List<SelectListItem>();
            StoryItems = new List<SelectListItem>();
            UserItems = new List<SelectListItem>();
        }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach(var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.Description
                });
            }
        }
        public void SetIntimacyItems(IEnumerable<Intimacy> intimacies)
        {
            foreach(var intimacy in intimacies)
            {
                IntimacyItems.Add(new SelectListItem()
                {
                    Value = intimacy.IntimacyId.ToString(),
                    Text = intimacy.Description
                });
            }
        }
        public void SetStoryItems(IEnumerable<Story> stories)
        {
            foreach (var story in stories)
            {
                StoryItems.Add(new SelectListItem()
                {
                    Value = story.StoryId.ToString(),
                    Text = story.Content
                });
            }
        }
        public void SetUserItems(IEnumerable<User> users)
            {
                foreach(var user in users)
                {
                UserItems.Add(new SelectListItem()
                {
                    Value = user.Id,
                    Text = user.Nickname
                });
                }
            }
    }
}
