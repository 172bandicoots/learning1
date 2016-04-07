using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class DBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DBContext() : base("name=DBContext")
        {
        }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.CourseRoster> CourseRosters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //            Shown are examples of bypassing the cascade delete, either for each table OR for the entire DbContext 
            //
                //        modelBuilder.Entity<Course>().HasOptional(m => m.Menu).WithOptionalDependent().WillCascadeOnDelete(false);
               //         modelBuilder.Entity<Student>().HasOptional(m => m.Menu).WithOptionalDependent().WillCascadeOnDelete(false);
              //          modelBuilder.Entity<CourseRoster>().HasOptional(m => m.MenuGroup).WithOptionalDependent().WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Assignment> Assignments { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Grade> Grades { get; set; }
    }
}
