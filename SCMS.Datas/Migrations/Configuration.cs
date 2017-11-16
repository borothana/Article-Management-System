namespace SCMS.Datas.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SCMS.Datas.DBContext.SCMSDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCMS.Datas.DBContext.SCMSDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userMgr = new UserManager<SCMS.Models.User>(new UserStore<SCMS.Models.User>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            // Create member role
            string curRoleID = "member", curUserName = "member", password = "12345678";

            if (!roleMgr.RoleExists(curRoleID))
            {
                roleMgr.Create(new IdentityRole { Name = curRoleID });
            }
            var user = new SCMS.Models.User
            {
                UserName = curUserName,
                Nickname = "member",
                IsActive = true
            };

            // if user existed
            if (!userMgr.Users.Any(u => u.UserName == curUserName))
            {
                userMgr.Create(user, password);
            }

            var tmpuser = userMgr.Users.Single(u => u.UserName == curUserName);
            if (!tmpuser.Roles.Any(r => r.RoleId == curRoleID))
            {
                userMgr.AddToRole(tmpuser.Id, curRoleID);
            }


            // Create admin role
            curRoleID = "admin"; curUserName = "scms"; password = "12345678";
            if (!roleMgr.RoleExists(curRoleID))
            {
                roleMgr.Create(new IdentityRole { Name = curRoleID });
            }

            user = new SCMS.Models.User
            {
                UserName = curUserName,
                Nickname = "scms",
                IsActive = true
            };

            // if user existed
            if (!userMgr.Users.Any(u => u.UserName == curUserName))
            {
                userMgr.Create(user, password);
            }

            tmpuser = userMgr.Users.Single(u => u.UserName == curUserName);
            if (!tmpuser.Roles.Any(r => r.RoleId == curRoleID))
            {
                userMgr.AddToRole(tmpuser.Id, curRoleID);
            }
        }
    }
}
