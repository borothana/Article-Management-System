using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SCMS.Models;

namespace SCMS.Datas.DBContext
{
    public class SCMSDBContext:IdentityDbContext<User>
    {
        public SCMSDBContext():base("SCMSDBString")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Intimacy> Intimacies { get; set; }
        public DbSet<Story> Stories { get; set; }      
        public DbSet<Info> Infos { get; set; }
    }
}
