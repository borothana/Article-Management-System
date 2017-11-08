 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class Story
    {
        public Story()
        {
            this.Hashtags = new HashSet<Hashtag>();
        }
        [Key]
        public int StroyId { get; set; }
        public int CategoryId { get; set; }
        public int IntimacyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HashtagWord { get; set; }
        public byte[] Picture { get; set; }
        public int NoView { get; set; }
        public char ApproveStatue { get; set; }
        public string Feedback { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Intimacy Intimacy { get; set; }

        public virtual ICollection<Hashtag> Hashtags { get; set; }
    }
}
