using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task RegisterUserAsync(UserRegistrationModel model);

    }
}
