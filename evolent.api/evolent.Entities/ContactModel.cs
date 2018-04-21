using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace evolent.Entities
{
    public class ContactModel
    { 
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Id required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number required.")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }      
}
