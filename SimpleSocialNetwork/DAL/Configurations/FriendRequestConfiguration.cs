using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class FriendRequestConfiguration: IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasOne(u => u.RequestBy)
                .WithMany(w => w.FriendRequestSent)
                .HasForeignKey(f => f.RequestById).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.RequestTo)
                .WithMany(w => w.FriendRequestReceived)
                .HasForeignKey(f => f.RequestToId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
