using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCMS.Models.ViewModels
{
    public class StoryVM
    {
        public StoryVM()
        {
            this.Hashtags = new HashSet<Hashtag>();
            CategoryItems = new List<SelectListItem>();
            IntimacyItems = new List<SelectListItem>();
        }

        public int StroyId { get; set; }
        public int CategoryId { get; set; }
        public int IntimacyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HashtagWord { get; set; }
        public byte[] Picture { get; set; }
        public int NoView { get; set; }
        public char ApproveStatue { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Intimacy Intimacy { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }

        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> IntimacyItems { get; set; }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = Category.CategoryId.ToString(),
                    Text = category.Description
                });
            }
        }

        public void SetIntimacyItems(IEnumerable<Intimacy> intimacies)
        {
            foreach (var intimacy in intimacies)
            {
                IntimacyItems.Add(new SelectListItem()
                {
                    Value = Intimacy.IntimacyId.ToString(),
                    Text = Intimacy.Description
                });
            }
        }
    }
}
