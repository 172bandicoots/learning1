using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class Grade
    {
        [Key]
        public int GradeID{ get; set; }

        [ForeignKey("Students")]
        public int StudentID { get; set; }
        public Student Students { get; set; }

       [ForeignKey("Assignments")] // foreign key value
       public int AssignmentID { get; set; } // what I am getting
       public Assignment Assignments { get; set; }  //where it gets it from  create object course and passing object into foreign key

        public int Score { get; set; }

    }
}