using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class IdentityManagers : IIdentityManagers
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }

        public IdentityManagers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }
    }
}
