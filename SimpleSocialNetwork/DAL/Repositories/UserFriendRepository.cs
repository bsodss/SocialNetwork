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
            return await _db.UserFriends.FirstOrDefaultAsync(i => i.UserId == id);
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
            await Task.Run(()=> _db.UserFriends.Remove(_db.UserFriends.FirstOrDefaultAsync(i=>i.UserId==id).Result));
        }

        public IQueryable<UserFriend> FindAllWithDetails()
        {
            return _db.UserFriends.Include(c => c.User)
                .Include(c => c.Friend);
        }

        public async Task<UserFriend> GetByIdWithDetailsAsync(int id)
        {
            return await FindAllWithDetails().FirstOrDefaultAsync(i => i.UserId == id);
        }
    }
}
