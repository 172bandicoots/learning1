using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase2.Models
{
    public class Course
    {
        [Key]
        public int CoursetID { get; set; }

        [Display(Name = "Course Title"), Required]
        public String CourseTitle { get; set; }

    }
}