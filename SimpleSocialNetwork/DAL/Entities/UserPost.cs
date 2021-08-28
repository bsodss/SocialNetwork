using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserPost:BaseEntity
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }

        //TODO: Attachments 

        public User User { get; set; }
    }
}
