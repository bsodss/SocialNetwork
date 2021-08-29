using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class FriendShip
    {
        public int MeId { get; set; }
        public User Me { get; set; }

        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}
