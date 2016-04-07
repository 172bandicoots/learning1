using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        [Display(Name = "Assignment Name"), Required]
        public String AssignmentName{ get; set; }

        public List<Grade> Grades { get; set; } // 1:n relationship with Course Rosters
    }
}


