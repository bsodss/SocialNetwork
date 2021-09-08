using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public UserManager<User> userManager
        {
            get => _userManager;
        }


        public SignInManager<User> signInManager
        {
            get => _signInManager;
        }

    }
}
