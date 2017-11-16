namespace SCMS.Datas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nickname = c.String(),
                        Phone = c.String(),
                        ProfilePic = c.Binary(),
                        Quote = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Descriptiopn = c.String(),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        IntimacyId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        HashtagWord = c.String(),
                        Picture = c.Binary(),
                        NoView = c.Int(nullable: false),
                        ApproveStatus = c.String(),
                        Feedback = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.StoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Intimacies", t => t.IntimacyId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.IntimacyId);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashtagId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.HashtagId);
            
            CreateTable(
                "dbo.Intimacies",
                c => new
                    {
                        IntimacyId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IntimacyId);
            
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        InfoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FDate = c.DateTime(nullable: false),
                        TDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InfoId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.HashtagStories",
                c => new
                    {
                        Hashtag_HashtagId = c.Int(nullable: false),
                        Story_StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hashtag_HashtagId, t.Story_StoryId })
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_HashtagId, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.Story_StoryId, cascadeDelete: true)
                .Index(t => t.Hashtag_HashtagId)
                .Index(t => t.Story_StoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "StoryId", "dbo.Stories");
            DropForeignKey("dbo.Stories", "IntimacyId", "dbo.Intimacies");
            DropForeignKey("dbo.HashtagStories", "Story_StoryId", "dbo.Stories");
            DropForeignKey("dbo.HashtagStories", "Hashtag_HashtagId", "dbo.Hashtags");
            DropForeignKey("dbo.Stories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.HashtagStories", new[] { "Story_StoryId" });
            DropIndex("dbo.HashtagStories", new[] { "Hashtag_HashtagId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stories", new[] { "IntimacyId" });
            DropIndex("dbo.Stories", new[] { "CategoryId" });
            DropIndex("dbo.Comments", new[] { "StoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.HashtagStories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Infoes");
            DropTable("dbo.Intimacies");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Stories");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Blogs");
        }
    }
}
