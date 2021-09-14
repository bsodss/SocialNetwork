using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserAccountRepository UserAccountRepository { get; }
        IFriendRequestRepository FriendRequestRepository { get; }
        IUserAccountPostRepository UserAccountPostRepository { get; } 
        IUserAccountFriendRepository UserAccountFriendRepository { get; }
        Task<int> SaveAsync();
    }
}
