using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Validation Attributes
using System.Linq;
using System.Web;

namespace MVC_Batch35.Models
{
    public class Customer
    {
        [Required(ErrorMessage ="Enter ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kindly fill your Name")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name does not satisfy the condition")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string Name { get; set; }

        [Range(21, 45, ErrorMessage = "Not Eligible")]
        public int Age { get; set; }

        [Range(typeof(DateTime), "01-01-2010", "01-01-2022", ErrorMessage = "Not a Valid Date")]
         public DateTime DOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Mobile number is required")]
        public string Mobile { get; set; }

        [MinLength(10)]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}