using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models.ViewModels
{
    public class UserVMEdit : IdentityUser
    {   
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Invalid email address")]
        public override string Email { get; set; }
        [Required(ErrorMessage = "Nick name is required", AllowEmptyStrings = false)]
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Quote { get; set; }        
    }
}
