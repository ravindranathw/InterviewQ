namespace InterviewQ.Resources.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAndTestQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        TestQuestionID = c.Guid(nullable: false),
                        TestID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TestQuestionID).PrimaryKey(t=> t.TestID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tests");
            DropTable("dbo.TestQuestions");
        }
    }
}
