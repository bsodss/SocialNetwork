using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WepApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;


        public UserController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UserAccountModel>> GetAllUsers()
        {

            return new ObjectResult(_userAccountService.GetAll());
        }

        [HttpGet("{id}/useraccount")]
        public async Task<ActionResult<UserAccountModel>> GetUserAccountById(string id)
        {
            try
            {
                return new ObjectResult(await _userAccountService.GetByIdAsync(id));
            }
            catch (SocialNetworkException ex)
            {
                return NotFound(ex.Message);
            }

        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountModel>> GetUserById(string id)
        {
            try
            {
                return new ObjectResult(await _userAccountService.GetByIdAsync(id));
            }
            catch (SocialNetworkException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(string id)
        {
            
            try
            {
                await _userAccountService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (SocialNetworkException e)
            {
                return NotFound(e.Message);
            }
        }


    }
}
