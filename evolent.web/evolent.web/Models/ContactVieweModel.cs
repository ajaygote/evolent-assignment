using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace evolent.web.Models
{
    public class ContactViewModel
    { 
        public int ContactId { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        [Required(ErrorMessage = "Email Id required.")]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name required.")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "Phone Number required.")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}