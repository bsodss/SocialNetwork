using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

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
            throw new NotImplementedException();
        }

        public async Task<UserFriend> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(UserFriend entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserFriend entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserFriend entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserFriend> FindAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<UserFriend> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
