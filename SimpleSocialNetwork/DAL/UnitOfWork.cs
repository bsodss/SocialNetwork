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

        private IUserRepository _userRepository;

        private IUserPostRepository _userPostRepository;

        public UnitOfWork(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                return _userRepository;
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

        public IUserPostRepository UserPostRepository
        {
            get
            {
                if (_userPostRepository == null)
                {
                    _userPostRepository = new UserPostRepository(_db);
                }

                return _userPostRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
