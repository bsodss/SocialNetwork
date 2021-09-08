using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserAccountFriend
    {
        public string UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public string FriendId { get; set; }
        public UserAccount Friend { get; set; }
    }
}
