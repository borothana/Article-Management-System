using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class NewUser
    {
        [Required(ErrorMessage = "Please provide a user name.", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide a password.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Passwords must be 8 characters long.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The passwords you've entered don't match.")]
        public string ConfirmPassword { get; set; }
    }
}

