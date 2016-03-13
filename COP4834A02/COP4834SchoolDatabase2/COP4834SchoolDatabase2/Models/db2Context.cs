using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase2.Models
{
    public class db2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public db2Context() : base("name=db2Context")
        {
        }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase2.Models.CourseRoster> CourseRosters { get; set; }
    }
}
