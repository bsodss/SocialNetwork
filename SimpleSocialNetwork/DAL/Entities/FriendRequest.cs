using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class FriendRequest :BaseEntity
    {
        public string RequestById { get; set; }
        public UserAccount RequestBy { get; set; }


        public string RequestToId { get; set; }
        public UserAccount RequestTo { set; get; }
        public bool IsConfirmed { get; set; }

    }
}
