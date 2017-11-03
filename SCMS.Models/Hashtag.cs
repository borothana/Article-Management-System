using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class Hashtag
    {
        public Hashtag()
        {
            this.Stories = new HashSet<Story>();
        }
        public int HashtagId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
