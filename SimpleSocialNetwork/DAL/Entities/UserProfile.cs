using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public string UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }
        public string City { get; set; }
        public bool IsMale { get; set; }
        public byte[] MainPhoto { get; set; }
    }
}
