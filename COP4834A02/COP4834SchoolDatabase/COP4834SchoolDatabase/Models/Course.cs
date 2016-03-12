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
        public int CourseID { get; set; }

        [Required, Display(Name = "Title")]
        public string CourseTitle { get; set; }

        [Required, Display(Name = "Description")]
        public String CourseDescription { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }

    }
}