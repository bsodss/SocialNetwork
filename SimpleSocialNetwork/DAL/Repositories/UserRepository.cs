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
    public class UserRepository:IUserRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }
        public IQueryable<User> FindAll()
        {
            return _db.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
        }

        public void Update(User entity)
        {
            _db.Users.Update(entity);
        }

        public void Delete(User entity)
        {
            _db.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(()=> _db.Users.Remove(_db.Users.First(i => i.Id == id)));
        }

        public IQueryable<User> FindAllWithDetails()
        {
            return _db.Users.Include(i => i.Friends).Include(i=>i.Posts);
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            return await FindAllWithDetails().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
