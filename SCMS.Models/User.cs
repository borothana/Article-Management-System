using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMS.Models
{
    public class User: IdentityUser
    {
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Quote { get; set; }
        public bool IsActive { get; set; }
    }
}
