using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.JwtFeatures;
using BLL.Models;
using BLL.Models.Auth;
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
        private readonly JwtHandler _jwtHandler;

        public UserService(IUnitOfWork uoW, IIdentityManagers identityManagers, JwtHandler jwtHandler)
        {
            _identityManagers = identityManagers;
            _jwtHandler = jwtHandler;
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
                //await _identityManagers.SignInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task<AuthResponseModel> LogInUserAsync(LogInModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("You did not provide correct data", nameof(RegisterUserAsync));
            }

            var user = await _identityManagers.UserManager.FindByEmailAsync(model.Email);

            if (user == null || !await _identityManagers.UserManager.CheckPasswordAsync(user, model.Password))
                return new AuthResponseModel() {IsAuthSuccessful = false, ErrorMessage = "Invalid Authentication" };
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user, (await _identityManagers.UserManager.GetRolesAsync(user)).FirstOrDefault());
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new AuthResponseModel()
            {
                IsAuthSuccessful = true,
                Token = token
            };
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
