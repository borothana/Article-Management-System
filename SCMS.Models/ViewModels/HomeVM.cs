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

        public List<SelectListItem> CategoryItems { get; set; }
        public List<SelectListItem> IntimacyItems { get; set; }

        public HomeVM()
        {
            CategoryItems = new List<SelectListItem>();
            IntimacyItems = new List<SelectListItem>();
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
    }
}
