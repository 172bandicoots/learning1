﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Display(Name = "Student Name"), Required]
        public String StudentName { get; set; }

        public List<CourseRoster> CourseRosters { get; set; } // 1:n relationship with Course Rosters
        public List<Grade> Grades { get; set; } //1:n relationship with Grade
    }
}