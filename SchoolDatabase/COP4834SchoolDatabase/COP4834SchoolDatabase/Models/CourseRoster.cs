using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class CourseRoster
    {

        [Key]
        public int RosterID { get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }
        public Student Students { get; set; }

        [ForeignKey("Courses")] // foreign key value
        public int CourseID { get; set; } // what I am getting
        public Course Courses { get; set; }  //where it gets it from  create object course and passing object into foreign key


    }
}