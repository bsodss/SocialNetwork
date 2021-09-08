using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class UserAccountPost : BaseEntity
    {
        public string? UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }


        //TODO: Attachments 
    }
}
