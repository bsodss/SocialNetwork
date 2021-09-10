using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Configurations;
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

            modelBuilder.ApplyConfiguration(new UserAccountFriendConfiguration());
            modelBuilder.ApplyConfiguration(new FriendRequestConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }

   
}
