using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SocialNetworkDbContext : DbContext
    {

        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserFriends config
            modelBuilder.Entity<UserFriend>()
                .HasKey(i => new { i.UserId, i.FriendId });

            modelBuilder.Entity<UserFriend>()
                .HasOne(c => c.User)
                .WithMany(w => w.FriendsAddedByMe)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>()
                .HasOne(c => c.Friend)
                .WithMany(w => w.FriendsWhoAddedMe)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // FriendRequest config
            modelBuilder.Entity<FriendRequest>().HasOne(u => u.RequestBy)
                .WithMany(w => w.FriendRequestSent)
                .HasForeignKey(f => f.RequestById).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FriendRequest>().HasOne(u => u.RequestTo)
                .WithMany(w => w.FriendRequestReceived)
                .HasForeignKey(f => f.RequestToId).OnDelete(DeleteBehavior.Restrict);
        }



    }
}
