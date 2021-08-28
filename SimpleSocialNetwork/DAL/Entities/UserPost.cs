using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class UserPost : BaseEntity
    {
        public int? UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }


        //TODO: Attachments 
    }
}
