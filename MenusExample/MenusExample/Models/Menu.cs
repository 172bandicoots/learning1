using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COP4709MenuDatabase.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }

        [Display(Name = "Title")]
        public string MenuTitle { get; set; }

        [Display(Name = "Description")]
        public string MenuDescription { get; set; }

        public virtual List<MenuItem> MenuItems { get; set; }

        public virtual List<MenuGroup> MenuGroups { get; set; }
    }
}