namespace DataCrowds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Responses", new[] { "SurveyId" });
            AlterColumn("dbo.Responses", "SurveyId", c => c.Int());
            CreateIndex("dbo.Responses", "SurveyId");
            AddForeignKey("dbo.Responses", "SurveyId", "dbo.Surveys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Responses", new[] { "SurveyId" });
            AlterColumn("dbo.Responses", "SurveyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Responses", "SurveyId");
            AddForeignKey("dbo.Responses", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
    }
}
