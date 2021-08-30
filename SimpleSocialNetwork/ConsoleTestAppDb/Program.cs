using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTestAppDb
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // ... Other properties

        public ICollection<UserFriend> Friends { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            //await CreatingAddingUsers();
            //await using (var db = new SocialNetworkDbContextFactory().CreateDbContext(new[] { "" }))
            //{
            //    var user1 = db.Users.Include(i => i.UserFriends).ThenInclude(t=>t.User)
            //        .FirstOrDefault(i=>i.Id==2);
            //    Console.WriteLine($"{user1.UserFriends.FirstOrDefault().UserId}");
            //}

        }

        static async Task CreatingAddingUsers()
        {
            var user1 = new User()
            {
                FirstName = "Maksym",
                LastName = "Snezhock"
            };

            var user2 = new User()
            {
                FirstName = "Oleh",
                LastName = "Yarosh"
            };

            await using (var db = new SocialNetworkDbContextFactory().CreateDbContext(new[] { "" }))
            {
                await db.AddRangeAsync(user1, user2);
                await db.SaveChangesAsync();
                var ufr = new UserFriend()
                {
                    UserId = 1,
                    FriendId = 2
                };
                

                await db.SaveChangesAsync();
            }
        }
    }
}

