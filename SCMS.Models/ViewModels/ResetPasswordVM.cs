using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models.ViewModels
{
    public class ResetPasswordVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordRetype { get; set; }
        public string ReturnUrl { get; set; }
    }
}
