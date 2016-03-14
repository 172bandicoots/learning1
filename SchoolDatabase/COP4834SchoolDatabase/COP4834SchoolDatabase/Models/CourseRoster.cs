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
        [Display(Name = "Roster ID")]
        public int RosterID { get; set; }

        [Display(Name = "Title")]
        public string SectionTitle { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

  



    }
}