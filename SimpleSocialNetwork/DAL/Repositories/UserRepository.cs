using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

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
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
