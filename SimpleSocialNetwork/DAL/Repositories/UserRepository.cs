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
    public class UserAccountRepository:IUserAccountRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserAccountRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }
        public IQueryable<UserAccount> FindAll()
        {
            return _db.UserAccounts;
        }

        public async Task<UserAccount> GetByIdAsync(string id)
        {
            return await _db.UserAccounts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(UserAccount entity)
        {
            await _db.UserAccounts.AddAsync(entity);
        }

        public void Update(UserAccount entity)
        {
            _db.UserAccounts.Update(entity);
        }

        public void Delete(UserAccount entity)
        {
            _db.UserAccounts.Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await Task.Run(()=> _db.UserAccounts.Remove(_db.UserAccounts.First(i => i.Id == id)));
        }

        public IQueryable<UserAccount> FindAllWithDetails()
        {
            return _db.UserAccounts.Include(c => c.FriendRequestSent)
                .Include(c => c.FriendRequestReceived)
                .Include(c => c.FriendsAddedByMe)
                .ThenInclude(t => t.Friend)
                .Include(c => c.FriendsWhoAddedMe)
                .ThenInclude(c => c.UserAccount);
        }

        public async Task<UserAccount> GetByIdWithDetailsAsync(string id)
        {
            return await FindAllWithDetails().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
