using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public bool IsMale { get; set; }
        public byte[] MainPhoto { get; set; }

        public ICollection<int> UserFriendsIds { get; set; }

        public ICollection<int> FriendRequestSentIds { get; set; }
        public ICollection<int> FriendRequestReceivedIds { get; set; }
        public ICollection<int> PostsIds { get; set; }
    }
}
