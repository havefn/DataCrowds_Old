namespace DataCrowds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquestionmodelkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Type = c.String(),
                        DataSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataSets", t => t.DataSet_Id)
                .Index(t => t.DataSet_Id);
            
            AddColumn("dbo.Answers", "QuestionViewModel_Id", c => c.Int());
            CreateIndex("dbo.Answers", "QuestionViewModel_Id");
            AddForeignKey("dbo.Answers", "QuestionViewModel_Id", "dbo.QuestionViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionViewModels", "DataSet_Id", "dbo.DataSets");
            DropForeignKey("dbo.Answers", "QuestionViewModel_Id", "dbo.QuestionViewModels");
            DropIndex("dbo.QuestionViewModels", new[] { "DataSet_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionViewModel_Id" });
            DropColumn("dbo.Answers", "QuestionViewModel_Id");
            DropTable("dbo.QuestionViewModels");
        }
    }
}
