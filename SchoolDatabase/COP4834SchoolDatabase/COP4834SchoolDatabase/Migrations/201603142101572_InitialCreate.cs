namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRosters",
                c => new
                    {
                        RosterID = c.Int(nullable: false, identity: true),
                        SectionTitle = c.String(),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RosterID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        CourseRoster_RosterID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.CourseRosters", t => t.CourseRoster_RosterID)
                .Index(t => t.CourseRoster_RosterID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CoursetID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CoursetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseRoster_RosterID", "dbo.CourseRosters");
            DropIndex("dbo.Students", new[] { "CourseRoster_RosterID" });
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRosters");
        }
    }
}
