using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUserAccountService:ICrud<UserAccountModel>
    {
        IEnumerable<UserAccountModel> GetByFilter(UserAccountFilterSearchModel filter);
    }
}
