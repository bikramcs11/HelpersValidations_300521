using HelpersValidations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersValidations.Models
{
    public class UserModel
    {
     
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage ="Please Enter Correct Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }

        [RegularExpression("^[6,7,8,9]\\{9}$", ErrorMessage = "Please Enter Correct ContactNo")]
        public string Contact { get; set; }

        [ValidateDropdown(ErrorMessage = "Please select Country")]
        public string Country { get; set; }

        [ValidateDropdown(ErrorMessage = "Please select City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }
    }
}
