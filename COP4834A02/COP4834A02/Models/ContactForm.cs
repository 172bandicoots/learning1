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

       [Required]
       [StringLength(15)]
       public string FirstName { get; set; }

       [Required]
       [StringLength(25)]
       public string LastName { get; set; }

       [Required]
       [StringLength(50)]
       public string Address { get; set; }

       [Required]
       [StringLength(25)]
       public string City { get; set; }

       [Required]
         ///////////////////needs code to shoose from a list of states
       public string State { get; set; }

       [Required]
       [DataType(DataType.PostalCode)]
       [StringLength(5)]
        ////restriction must be all numbers too - needs code
       public String Zipcode { get; set; }

       [Required]
       [DataType(DataType.PhoneNumber)]
       public string PhoneNumber { get; set; }

       [Required]
       [DataType(DataType.EmailAddress)]
        ///////////needs code to restric future dates or very young people
       public string Email { get; set; }

       [Required]
       [DataType(DataType.Date)]
       public String BirthDate { get; set; }

       [Required]
       [DataType(DataType.MultilineText)]
       [StringLength(400)]
       public string Message { get; set; }
    }
}
