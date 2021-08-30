using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IFriendRequestRepository: IRepository<FriendRequest>
    {
        IQueryable<FriendRequest> FindAllWithDetails();
    }
}
