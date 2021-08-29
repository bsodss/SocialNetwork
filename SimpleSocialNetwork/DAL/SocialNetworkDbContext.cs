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
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserFriend>().HasOne(u => u.User)
                .WithMany(w => w.Friends)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);


            //added for the test
            var user1 = new User
            {
                Id = 1,
                FirstName = "Mike",
                LastName = "Brown",
                Birthday = new DateTime(2002,5,2),
                IsMale = true,
                MainPhoto = null,
                City = "Kiev",
            };
            var user2 = new User
            {
                Id = 2,
                FirstName = "John",
                LastName = "West",
                Birthday = new DateTime(2007, 9, 7),
                IsMale = true,
                MainPhoto = null,
                City = "Vinnitsia",
            };
            modelBuilder.Entity<User>().HasData(user1, user2);

            var friend = new UserFriend
            {
                Id = 1,
                UserId = user1.Id,
                FriendId = user2.Id,
                //User = user1,
                //Friend = user2,
                IsConfirmed = false
            };
            modelBuilder.Entity<UserFriend>().HasData(friend);

        }

    }
}
