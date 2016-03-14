using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class db3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public db3Context() : base("name=db3Context")
        {
        }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<COP4834SchoolDatabase.Models.CourseRoster> CourseRosters { get; set; }
    }
}
