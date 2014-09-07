namespace InterviewQ.Resources.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAndTestQU : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TestQuestions");
            AddPrimaryKey("dbo.TestQuestions", new[] { "TestID", "TestQuestionID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TestQuestions");
            AddPrimaryKey("dbo.TestQuestions", "TestQuestionID");
        }
    }
}
