using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserPostRepository: IUserPostRepository
    {
        private readonly SocialNetworkDbContext _db;

        public UserPostRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public Task AddAsync(UserPost entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserPost entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserPost> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserPost> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserPost entity)
        {
            throw new NotImplementedException();
        }
    }
}
