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
        public List<Category> Category { get; set; }
        public List<Intimacy> Intimacy { get; set; }
        public List<Story> StoryVM { get; set; }
        public List<User> User { get; set; }
        public bool IsSelected { get; set; }
        public Hashtag Hashtag { get; set; }
        public List<int> CategoryIdSearch { get; set; }
        public List<int> IntimacyIdSearch { get; set; }
        public string UserNameSearch { get; set; }
        public string HashtagSearch { get; set; }
        public string TitleSearch { get; set; }
      


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
            CategoryItems = new List<SelectListItem>();
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
            IntimacyItems = new List<SelectListItem>();
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
            StoryItems = new List<SelectListItem>();
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
            UserItems = new List<SelectListItem>();
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
