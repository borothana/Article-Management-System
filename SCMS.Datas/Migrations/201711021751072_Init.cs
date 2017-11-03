namespace SCMS.Datas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "HashtagWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "HashtagWord");
        }
    }
}
