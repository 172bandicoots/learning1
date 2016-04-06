namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseRosters",
                c => new
                    {
                        RosterID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RosterID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CoursetID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CoursetID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseRosters", new[] { "CourseID" });
            DropIndex("dbo.CourseRosters", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseRosters");
        }
    }
}
