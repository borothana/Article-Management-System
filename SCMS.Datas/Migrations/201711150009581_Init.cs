namespace SCMS.Datas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Infoes", "FDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Infoes", "TDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Infoes", "TDate", c => c.DateTime());
            AlterColumn("dbo.Infoes", "FDate", c => c.DateTime());
        }
    }
}
