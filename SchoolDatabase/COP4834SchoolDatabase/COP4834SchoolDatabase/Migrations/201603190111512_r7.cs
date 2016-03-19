namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Courses", "SectionID", "dbo.Sections");
            AddForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses", "CoursetID", cascadeDelete: true);
            AddForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "SectionID", "dbo.Sections", "SectionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses");
            AddForeignKey("dbo.Courses", "SectionID", "dbo.Sections", "SectionID");
            AddForeignKey("dbo.CourseRosters", "StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.CourseRosters", "CourseID", "dbo.Courses", "CoursetID");
        }
    }
}
