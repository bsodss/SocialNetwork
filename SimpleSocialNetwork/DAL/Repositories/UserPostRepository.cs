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
    public class UserPostRepository: IUserPostRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserPostRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(UserPost entity)
        {
            await _db.UserPosts.AddAsync(entity);
        }

        public void Delete(UserPost entity)
        {
            _db.UserPosts.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            _db.UserPosts.Remove(_db.UserPosts.First(i=> i.Id==id));
        }

        public IQueryable<UserPost> FindAll()
        {
            return _db.UserPosts;
        }

        public async Task<UserPost> GetByIdAsync(int id)
        {
            return await _db.UserPosts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Update(UserPost entity)
        {
            _db.UserPosts.Update(entity);
        }
    }
}
