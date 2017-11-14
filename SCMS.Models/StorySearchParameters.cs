using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class StorySearchParameters
    {
        public string QuickSearch { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public string Hashtag { get; set; }
        public int? Category { get; set; }
        public int? Intimacy { get; set; }
    }
}
