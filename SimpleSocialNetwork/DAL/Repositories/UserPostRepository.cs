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
    public class UserAccountPostRepository: IUserAccountPostRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserAccountPostRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(UserAccountPost entity)
        {
            await _db.UserAccountPosts.AddAsync(entity);
        }

        public void Delete(UserAccountPost entity)
        {
            _db.UserAccountPosts.Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            _db.UserAccountPosts.Remove(_db.UserAccountPosts.First(i=> i.Id==id));
        }

        public IQueryable<UserAccountPost> FindAll()
        {
            return _db.UserAccountPosts;
        }

        public async Task<UserAccountPost> GetByIdAsync(string id)
        {
            return await _db.UserAccountPosts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Update(UserAccountPost entity)
        {
            _db.UserAccountPosts.Update(entity);
        }
    }
}
