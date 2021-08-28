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

        }

    }
}
