using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserFriendRepository:IUserFriendRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserFriendRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public IQueryable<UserFriend> FindAll()
        {
            return _db.UserFriends;
        }

        public async Task<UserFriend> GetByIdAsync(int id)
        {
            return _db.UserFriends.FirstOrDefault(i => i.Id == id);
        }

        public async Task AddAsync(UserFriend entity)
        {
            await _db.UserFriends.AddAsync(entity);
        }

        public void Update(UserFriend entity)
        {
            _db.UserFriends.Update(entity);
        }

        public void Delete(UserFriend entity)
        {
            _db.UserFriends.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(()=>_db.Remove(_db.UserFriends.First(i => i.Id == id)));
        }

        public IQueryable<UserFriend> FindAllWithDetails()
        {
            return _db.UserFriends.Include(i => i.User)
                .Include(i => i.Friend);
        }
    }
}
