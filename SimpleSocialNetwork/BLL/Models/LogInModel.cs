using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class LogInModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required] 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
