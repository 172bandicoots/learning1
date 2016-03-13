namespace COP4834SchoolDatabase2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r2 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Courses");
        }
    }
}
