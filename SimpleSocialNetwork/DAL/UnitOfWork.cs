using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkDbContext _db;
        private IFriendRequestRepository _FriendRequestRepository;

        private IUserAccountRepository _UserAccountRepository;

        private IUserAccountPostRepository _UserAccountPostRepository;

        public UnitOfWork(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public IUserAccountRepository UserAccountRepository
        {
            get
            {
                if (_UserAccountRepository == null)
                {
                    _UserAccountRepository = new UserAccountRepository(_db);
                }

                return _UserAccountRepository;
            }
        }

        public IFriendRequestRepository FriendRequestRepository
        {
            get
            {
                if (_FriendRequestRepository == null)
                {
                    _FriendRequestRepository = new FriendRequestRepository(_db);
                }

                return _FriendRequestRepository;
            }
        }

        public IUserAccountPostRepository UserAccountPostRepository
        {
            get
            {
                if (_UserAccountPostRepository == null)
                {
                    _UserAccountPostRepository = new UserAccountPostRepository(_db);
                }

                return _UserAccountPostRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
