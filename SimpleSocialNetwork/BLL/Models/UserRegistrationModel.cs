using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class UserRegistrationModel
    {
        public string Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required] public DateTime Birthday { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equals")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
