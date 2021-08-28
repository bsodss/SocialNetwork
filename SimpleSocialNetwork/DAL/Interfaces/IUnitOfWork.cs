using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserFriendRepository UserFriendRepository { get; }
        IUserPostRepository UserPostRepository { get; }
        Task<int> SaveAsync();
    }
}
