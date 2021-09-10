using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class UserAccountFriendConfiguration: IEntityTypeConfiguration<UserAccountFriend>
    {
        public void Configure(EntityTypeBuilder<UserAccountFriend> builder)
        {
            builder.HasKey(i => new { i.UserAccountId, i.FriendId });

            builder.HasOne(c => c.UserAccount)
                .WithMany(w => w.FriendsAddedByMe)
                .HasForeignKey(f => f.UserAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Friend)
                .WithMany(w => w.FriendsWhoAddedMe)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
