using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Descriptiopn { get; set; }
        public int StoryId { get; set; }

        public virtual Story Story { get; set; }
    }
}
