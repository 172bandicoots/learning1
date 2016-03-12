using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COP4834SchoolDatabase.Models
{
    public class Book
    {

        [Key]
        public int BookID { get; set; }

        [Display(Name = "Title"), Required]
        public String BookTitle { get; set; }

        [Display(Name = "Description"), Required]
        public String BookDescription { get; set; }
    }
}