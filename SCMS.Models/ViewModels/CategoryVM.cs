using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool isSelected { get; set; }
    }
}

