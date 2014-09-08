namespace InterviewQ.Resources.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DifficultyEnumAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DifficultyLevels", "Difficulty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DifficultyLevels", "Difficulty", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
