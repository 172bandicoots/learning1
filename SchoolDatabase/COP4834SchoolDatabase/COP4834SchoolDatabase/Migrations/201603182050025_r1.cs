namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
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
                        Section_SectionID = c.Int(),
                    })
                .PrimaryKey(t => t.RosterID)
                .ForeignKey("dbo.Sections", t => t.Section_SectionID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.Section_SectionID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CoursetID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false),
                        SectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoursetID)
                .ForeignKey("dbo.Sections", t => t.SectionID)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        SectionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SectionID);
            
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
            DropForeignKey("dbo.Courses", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.CourseRosters", "Section_SectionID", "dbo.Sections");
            DropIndex("dbo.Courses", new[] { "SectionID" });
            DropIndex("dbo.CourseRosters", new[] { "Section_SectionID" });
            DropIndex("dbo.CourseRosters", new[] { "CourseID" });
            DropIndex("dbo.CourseRosters", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Sections");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseRosters");
        }
    }
}
