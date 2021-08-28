using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class UserFriend :BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }


        public int FriendId { get; set; }
        public User Friend { set; get; }
        public bool IsConfirmed { get; set; }


        //TODO: add chat prop
    }
}
