namespace COP4834SchoolDatabase2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r3 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseRosters");
        }
    }
}
