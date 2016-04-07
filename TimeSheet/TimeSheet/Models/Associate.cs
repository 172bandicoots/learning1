using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeSheet.Models
{
    public class Associate
    {
        [Key]
        public int AssociateID { get; set; }

        [Required, StringLength(20), Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }

        [Required, StringLength(25), Display(Name = "City")]
        public string City { get; set; }

        [Required, Display(Name = "State")]
        public String State { get; set; }

        [Required, DataType(DataType.PostalCode), RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Must be at correct 5 or full 9 digit format")]
        public String Zipcode { get; set; }

        [Required, Display(Name = "Phone Number"), RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Phone number must be ###-###-####")]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
        public string Email { get; set; }

        //Manually set by administrator, the log table cannot be written to or viewed if this 
        //flag is Null or false.  This is not visible from the associate views.
        public int ValidUser { get; set; }

        //set up one to many
        public virtual List<TimeLog> TimeLogs { get; set; }

    }
}