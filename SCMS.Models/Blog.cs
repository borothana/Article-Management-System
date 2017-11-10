using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual User User { get; set; }

    }
}
