using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTestAppDb
{

    class Program
    {
        static async Task Main(string[] args)
        {
            //await CreatingAddingUsers();
            //await using (var db = new SocialNetworkDbContextFactory().CreateDbContext(new[] { "" }))
            //{
            //    var user1 = db.Users.Include(c => c.FriendsAddedByMe)
            //        .Include(c => c.FriendsWhoAddedMe).FirstOrDefault(i => i.Id == 1);


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

            var user3 = new User()
            {
                FirstName = "Anna",
                LastName = "Hotsuliak"
            };

            await using (var db = new SocialNetworkDbContextFactory().CreateDbContext(new[] { "" }))
            {
                await db.AddRangeAsync(user1, user2, user3);
                await db.SaveChangesAsync();
                var ufr = new UserFriend()
                {
                    UserId = 1,
                    FriendId = 2
                };

                var fr = new UserFriend()
                {
                    FriendId = 1,
                    UserId = 3
                };

                db.UserFriends.AddRange(ufr, fr);

                await db.SaveChangesAsync();
            }
        }
    }
}

