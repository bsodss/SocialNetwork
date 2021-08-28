using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserFriend:BaseEntity
    {
        public int UserIdSource { get; set; }
        public int UserIdDestination { get; set; }
        public bool IsConfirmed { get; set; }

        //TODO: chat prop
    }
}
