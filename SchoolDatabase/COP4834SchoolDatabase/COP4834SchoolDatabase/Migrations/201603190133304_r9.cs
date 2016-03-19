namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Courses", "SectionID", "dbo.Sections");
            AddForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses", "CoursetID");
            AddForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.Courses", "SectionID", "dbo.Sections", "SectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses");
            AddForeignKey("dbo.Courses", "SectionID", "dbo.Sections", "SectionID", cascadeDelete: true);
            AddForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses", "CoursetID", cascadeDelete: true);
        }
    }
}
