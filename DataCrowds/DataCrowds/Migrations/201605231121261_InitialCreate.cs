namespace DataCrowds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        birthDate = c.DateTime(nullable: false),
                        occupation = c.String(),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        required = c.Boolean(nullable: false),
                        type = c.String(),
                        answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        maxRespondents = c.Int(nullable: false),
                        rewards = c.String(),
                        surveyFormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyForms");
            DropTable("dbo.Questions");
            DropTable("dbo.Profiles");
            DropTable("dbo.DataSets");
        }
    }
}
