using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class Course
    {
        [Key]
        public int CoursetID { get; set; }

        [Display(Name = "Course Title"), Required]
        public String CourseTitle { get; set; }

        [ForeignKey("Sections")]   //attribute to indicate the existance of a foreign key
        public int SectionID { get; set; } //the foreign key the attribute refers to
        public Section Sections { get; set; } //one Course to many sections

        public virtual List<CourseRoster> CourseRosters { get; set; } // 1:n

    }
}