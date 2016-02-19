using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4834A02.Models
{

    public class ContactForm
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ContactID { get; set; }

        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(25), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(50), Display(Name = "Address")]
        public string Address { get; set; }

        [Required, StringLength(25), Display(Name = "City")]
        public string City { get; set; }

        [Required, Display(Name = "State")]
        public String State { get; set; }

        [Required, DataType(DataType.PostalCode), RegularExpression(@"^\d{5}(-\d{4})?$",ErrorMessage ="Must be at correct 5 or full 9 digit format")]
        public String Zipcode { get; set; }

        [Required, Display(Name = "Phone Number"), RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Phone number must be ###-###-####")]
        public string PhoneNumber { get; set; }

       [Required, DataType(DataType.EmailAddress), Display(Name = "Email Address")]
       public string Email { get; set; }
       
       [Required, Display(Name = "Birthday"), DataType(DataType.Date), ValidateBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
       // Must be at least 5 years old
        public String BirthDate { get; set; }

       [Required, DataType(DataType.MultilineText), StringLength(400), Display(Name = "Message")]
       public string Message { get; set; }
    }
}
