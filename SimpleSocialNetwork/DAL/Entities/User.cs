using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public bool IsMale { get; set; }
        public byte[] MainPhoto { get; set; }

        public ICollection<UserFriend> FriendsAddedByMe { get; set; }
        public ICollection<UserFriend> FriendsWhoAddedMe{ get; set; }
        public ICollection<FriendRequest> FriendRequestSent { get; set; }
        public ICollection<FriendRequest> FriendRequestReceived { get; set; }
        public ICollection<UserPost> Posts { get; set; }

    }
}
