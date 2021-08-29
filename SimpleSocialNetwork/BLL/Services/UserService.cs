using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService:IUserService
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
