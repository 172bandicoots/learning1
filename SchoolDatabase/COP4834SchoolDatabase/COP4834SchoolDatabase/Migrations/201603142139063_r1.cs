namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "CourseRoster_RosterID", "dbo.CourseRosters");
            DropIndex("dbo.Students", new[] { "CourseRoster_RosterID" });
            DropColumn("dbo.Students", "CourseRoster_RosterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "CourseRoster_RosterID", c => c.Int());
            CreateIndex("dbo.Students", "CourseRoster_RosterID");
            AddForeignKey("dbo.Students", "CourseRoster_RosterID", "dbo.CourseRosters", "RosterID");
        }
    }
}
