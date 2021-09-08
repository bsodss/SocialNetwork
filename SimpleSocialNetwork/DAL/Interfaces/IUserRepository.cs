using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        IQueryable<UserAccount> FindAllWithDetails();
        Task<UserAccount> GetByIdWithDetailsAsync(string id);
    }
}
