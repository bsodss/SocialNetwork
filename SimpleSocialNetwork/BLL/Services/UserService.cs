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
using Microsoft.VisualBasic;

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

        public async Task RegisterUserAsync(UserRegistrationModel model)
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
                    User = user
                });
                await _identityManagers.SignInManager.SignInAsync(user, false);
            }

        }
    }
}
