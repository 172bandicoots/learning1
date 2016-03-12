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
        public String StduentName{ get; set; }
    }
}