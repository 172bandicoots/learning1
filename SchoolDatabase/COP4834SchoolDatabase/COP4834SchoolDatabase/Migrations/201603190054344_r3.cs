namespace COP4834SchoolDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRosters", "Section_SectionID", "dbo.Sections");
            DropIndex("dbo.CourseRosters", new[] { "Section_SectionID" });
            DropColumn("dbo.CourseRosters", "Section_SectionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseRosters", "Section_SectionID", c => c.Int());
            CreateIndex("dbo.CourseRosters", "Section_SectionID");
            AddForeignKey("dbo.CourseRosters", "Section_SectionID", "dbo.Sections", "SectionID");
        }
    }
}
