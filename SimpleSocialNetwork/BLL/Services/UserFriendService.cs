using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Services
{
    public class FriendRequestService:IFriendRequestService
    {
        public IEnumerable<FriendRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<FriendRequest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(FriendRequest model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(FriendRequest model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
