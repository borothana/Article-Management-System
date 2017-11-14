using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class Intimacy
    {
        public int IntimacyId { get; set; }
        public string Description { get; set; }
        public bool isSelected { get; set; }
    }
}
