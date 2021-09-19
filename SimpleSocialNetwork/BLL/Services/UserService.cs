using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IIdentityManagers _identityManagers;

        public UserService(IUnitOfWork uoW, IIdentityManagers identityManagers)
        {
            _identityManagers = identityManagers;
            
            _uow = uoW;
        }


        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("You did not provide correct data", nameof(RegisterUserAsync));
            }
            if (model.Password != model.ConfirmPassword)
            {
                throw new SocialNetworkException("Passwords are not equals", nameof(RegisterUserAsync));
            }

            var user = new User()
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _identityManagers.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _uow.UserAccountRepository.AddAsync(new UserAccount()
                {
                    User = user,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    IsMale = model.IsMale
                });
                await _uow.SaveAsync();
                if (await _identityManagers.RoleManager.RoleExistsAsync("User"))
                {
                    await _identityManagers.UserManager.AddToRoleAsync(user, "User");
                }

                await _identityManagers.SignInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task<SignInResult> LogInUserAsync(LogInModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("You did not provide correct data", nameof(RegisterUserAsync));
            }

            var user = await _identityManagers.UserManager.Users.SingleOrDefaultAsync(i => i.Email == model.Email);
            if (user == null)
            {
                throw new SocialNetworkException("User not found");
            }

            var result = await _identityManagers.SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            return result;

        }

        //TODO: Add RoleService
        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {

            if ((await _identityManagers.RoleManager.RoleExistsAsync(roleName)))
            {
                throw new SocialNetworkException("Role with such name is already exist!");
            }

            return await _identityManagers.RoleManager.CreateAsync(new IdentityRole(roleName));
        }

        public async Task LogOut()
        {
            await _identityManagers.SignInManager.SignOutAsync();
        }
    }
}
