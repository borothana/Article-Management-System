namespace SCMS.Datas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
