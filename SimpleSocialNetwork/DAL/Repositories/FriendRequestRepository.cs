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
    public class FriendRequestRepository: IFriendRequestRepository
    {
        private readonly SocialNetworkDbContext _db;

        public FriendRequestRepository(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public IQueryable<FriendRequest> FindAll()
        {
            return _db.FriendRequests;
        }

        public async Task<FriendRequest> GetByIdAsync(string id)
        {
            return await _db.FriendRequests.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(FriendRequest entity)
        {
            await _db.FriendRequests.AddAsync(entity);
        }

        public void Update(FriendRequest entity)
        {
            _db.FriendRequests.Update(entity);
        }

        public void Delete(FriendRequest entity)
        {
            _db.FriendRequests.Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await Task.Run(()=>_db.Remove(_db.FriendRequests.First(i => i.Id == id)));
        }

        public IQueryable<FriendRequest> FindAllWithDetails()
        {
            return _db.FriendRequests.Include(c => c.RequestBy)
                .Include(c => c.RequestTo);
        }
    }
}
