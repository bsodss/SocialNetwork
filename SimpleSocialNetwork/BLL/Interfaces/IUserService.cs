using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Models.Auth;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUserAsync(UserRegistrationModel model);
        public Task<AuthResponseModel> LogInUserAsync(LogInModel model);
        public Task LogOut();
        public  Task<IdentityResult> CreateRoleAsync(string roleName);
    }
}
