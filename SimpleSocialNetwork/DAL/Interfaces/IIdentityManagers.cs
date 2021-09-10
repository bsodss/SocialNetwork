using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IIdentityManagers
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public  SignInManager<User> SignInManager { get; }

    }
}
