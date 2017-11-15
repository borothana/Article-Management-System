using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SCMS.Models
{
    public class Info
    {
        public int InfoId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Invalid Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/2000", "12/31/2050", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2050")]
        public DateTime? FDate { get; set; }
        [Required(ErrorMessage = "Invalid End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/2000", "12/31/2050", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2050")]
        public DateTime? TDate { get; set; }
        [AllowHtml]
        public string Description { get; set; }
    }
}
