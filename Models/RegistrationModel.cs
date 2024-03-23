using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTreeMVCWebApplication.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2)]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "First Name cannot contain special characters or numbers")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Last Name cannot contain special characters or numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\+(?:1(?:[. -]|\d{3})|\d{3})([. -]|\d{3})([. -]|\d{4})$", ErrorMessage = "Phone number must be in North American format")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the user agreement")]
        [Display(Name = "Accept User Agreement")]
        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }
        public int CategoryId { get; set; }

    }
}
