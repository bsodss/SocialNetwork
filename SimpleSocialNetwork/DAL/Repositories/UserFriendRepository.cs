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
    public class UserAccountFriendRepository:IUserAccountFriendRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserAccountFriendRepository(SocialNetworkDbContext db)
        {
            _db = db;
            
        }

        public IQueryable<UserAccountFriend> FindAll()
        {
            return _db.UserAccountFriends;
        }

        public async Task<UserAccountFriend> GetByIdAsync(string id)
        {
            return await _db.UserAccountFriends.FirstOrDefaultAsync(i => i.UserAccountId == id);
        }

        public async Task AddAsync(UserAccountFriend entity)
        {
            await _db.UserAccountFriends.AddAsync(entity);
        }

        public void Update(UserAccountFriend entity)
        {
            _db.UserAccountFriends.Update(entity);
        }

        public void Delete(UserAccountFriend entity)
        {
            _db.UserAccountFriends.Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await Task.Run(()=> _db.UserAccountFriends.Remove(_db.UserAccountFriends.FirstOrDefaultAsync(i=>i.UserAccountId==id).Result));
        }

        public IQueryable<UserAccountFriend> FindAllWithDetails()
        {
            return _db.UserAccountFriends.Include(c => c.UserAccount)
                .Include(c => c.Friend);
        }

        public async Task<UserAccountFriend> GetByIdWithDetailsAsync(string id)
        {
            return await FindAllWithDetails().FirstOrDefaultAsync(i => i.UserAccountId == id);
        }
    }
}
