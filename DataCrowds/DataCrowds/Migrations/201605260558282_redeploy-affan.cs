namespace DataCrowds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redeployaffan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataSets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataSets", "UserId");
        }
    }
}
