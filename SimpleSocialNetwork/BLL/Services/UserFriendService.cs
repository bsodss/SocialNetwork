using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Services
{
    public class UserFriendService:IUserFriendService
    {
        public IEnumerable<UserFriend> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserFriend> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(UserFriend model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserFriend model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
