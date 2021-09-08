using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public UserManager<User> userManager { get; }
        public SignInManager<User> signInManager { get; }
    }
}
