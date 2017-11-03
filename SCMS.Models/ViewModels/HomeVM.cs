using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models.ViewModels
{
    public class HomeVM
    {
        public List<CategoryVM> CategoryCheckboxes { get; set; }
        public List<IntimacyVM> IntimacyCheckboxes { get; set; }
        public List<UserVM> SearchUsers { get; set; }
    }
}
