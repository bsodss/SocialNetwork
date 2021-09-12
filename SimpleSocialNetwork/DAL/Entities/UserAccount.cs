using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DAL.Entities
{
    public class UserAccount : BaseEntity
    {

        [Key]
        [ForeignKey("User")]
        public new string Id { get; set; }
        public User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string City { get; set; }
        public bool IsMale { get; set; }
        public byte[] MainPhoto { get; set; }

        public ICollection<UserAccountFriend> FriendsAddedByMe { get; set; }
        public ICollection<UserAccountFriend> FriendsWhoAddedMe { get; set; }

        public ICollection<FriendRequest> FriendRequestSent { get; set; }
        public ICollection<FriendRequest> FriendRequestReceived { get; set; }
        public ICollection<UserAccountPost> Posts { get; set; }

    }
}
