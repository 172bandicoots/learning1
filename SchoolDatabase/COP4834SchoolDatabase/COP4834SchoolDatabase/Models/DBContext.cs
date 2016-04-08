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

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Assignment> Assignments { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Grade> Grades { get; set; }

        public void DeleteStudent(int id)
        {
            //delete range in CourseRosters
            CourseRosters.RemoveRange(CourseRosters.Where(si => si.StudentID == id));
            //delete range in Grades
            Grades.RemoveRange(Grades.Where(ai => ai.StudentID == id));
            //delete Student
            Student Student = Students.Find(id);
            Students.Remove(Student);
            SaveChanges();

        }

        public void DeleteCourse(int id)
        {
            //delete range in CourseRosters
            CourseRosters.RemoveRange(CourseRosters.Where(si => si.CourseID == id));
            //delete Course
            Course Course = Courses.Find(id);
            Courses.Remove(Course);
            SaveChanges();
        }
        public void DeleteAssignment(int id)
        {
            //delete range in Grades
            Grades.RemoveRange(Grades.Where(si => si.AssignmentID == id));
            //delete Assignment
            Assignment Assignment = Assignments.Find(id);
            Assignments.Remove(Assignment);
            SaveChanges();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //            Shown are examples of bypassing the cascade delete, either for each table OR for the entire DbContext 
                //        modelBuilder.Entity<Course>().HasOptional(m => m.Menu).WithOptionalDependent().WillCascadeOnDelete(false);
               //         modelBuilder.Entity<Student>().HasOptional(m => m.Menu).WithOptionalDependent().WillCascadeOnDelete(false);
              //          modelBuilder.Entity<CourseRoster>().HasOptional(m => m.MenuGroup).WithOptionalDependent().WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           

            base.OnModelCreating(modelBuilder);
        }


    }
}
