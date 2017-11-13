using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models.ViewModels
{
    public class UserVM : IdentityUser
    {   
        [Required(ErrorMessage = "User name is required", AllowEmptyStrings = false)]
        public override string UserName { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Invalid email address")]
        public override string Email { get; set; }
        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Passwords must be 8 characters lenght")]
        public override string PasswordHash { get; set; }
        [Compare("PasswordHash", ErrorMessage = "Confirm password doesn't match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Nick name is required", AllowEmptyStrings = false)]
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Quote { get; set; }
        public bool IsActive { get; set; }

        public Response Result { get; set; }

    }
}
