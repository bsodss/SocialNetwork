using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserFriendRepository: IRepository<UserFriend>
    {
        IQueryable<User> FindAllWithDetails();
    }
}
