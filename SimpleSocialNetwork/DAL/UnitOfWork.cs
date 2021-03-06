using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;


namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkDbContext _db;
        private IFriendRequestRepository _FriendRequestRepository;

        private IUserAccountRepository _UserAccountRepository;

        private IUserAccountPostRepository _UserAccountPostRepository;

        private IUserAccountFriendRepository _userAccountFriendRepository;

        public UnitOfWork(SocialNetworkDbContext db)
        {
            _db = db;
        }

        public IUserAccountFriendRepository UserAccountFriendRepository
        {
            get
            {
                if (_userAccountFriendRepository == null)
                {
                    _userAccountFriendRepository = new UserAccountFriendRepository(_db);
                }

                return _userAccountFriendRepository;
            }
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
