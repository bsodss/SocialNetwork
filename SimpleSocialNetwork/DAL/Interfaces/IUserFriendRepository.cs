﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserAccountFriendRepository:IRepository<UserAccountFriend>
    {
        IQueryable<UserAccountFriend> FindAllWithDetails();
        Task<UserAccountFriend> GetByIdWithDetailsAsync(string id);
    }
}
