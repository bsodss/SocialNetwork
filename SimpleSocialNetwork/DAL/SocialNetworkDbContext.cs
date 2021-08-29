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
        public DbSet<UserFriend> UserFriends { get; set; }

        public DbSet<FriendShip> FriendShips { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendShip>().HasKey(k => new { k.MeId, k.FriendId });
            //modelBuilder.Entity<FriendShip>().HasOne(u => u.Me)
            //    .WithMany(m => m.Friends).HasForeignKey(k => k.MeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<FriendShip>().HasOne(u => u.Friend)
            //    .WithMany(m => m.Friends).HasForeignKey(k => k.FriendId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(u => u.User)
                .WithMany(w => w.FriendRequestSent)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriend>().HasOne(u => u.Friend)
                .WithMany(w => w.FriendRequestReceived)
                .HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.Restrict);


        }

    }
}
