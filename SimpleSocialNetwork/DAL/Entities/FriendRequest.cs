using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class FriendRequest :BaseEntity
    {
        public int RequestById { get; set; }
        public User RequestBy { get; set; }


        public int RequestToId { get; set; }
        public User RequestTo { set; get; }
        public bool IsConfirmed { get; set; }

    }
}
