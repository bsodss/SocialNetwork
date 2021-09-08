using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SocialNetworkDbContext :IdentityDbContext<User>
    {

        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountPost> UserAccountPosts { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<UserAccountFriend> UserAccountFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // UserAccountFriends config
            modelBuilder.Entity<UserAccountFriend>()
                .HasKey(i => new { i.UserAccountId, i.FriendId });

            modelBuilder.Entity<UserAccountFriend>()
                .HasOne(c => c.UserAccount)
                .WithMany(w => w.FriendsAddedByMe)
                .HasForeignKey(f => f.UserAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAccountFriend>()
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

            base.OnModelCreating(modelBuilder);
        }

    }

   
}
