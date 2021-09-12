using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WepApi.Controllers
{
    [Authorize]
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


        [HttpGet]
        public ActionResult<IEnumerable<UserAccountModel>> GetAllUsers()
        {
            return new ObjectResult( _userAccountService.GetAll());
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<UserAccountModel>> GetUserById(string id)
        {
            return new ObjectResult(await _userAccountService.GetByIdAsync(id));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(string id)
        {
            await _userAccountService.DeleteByIdAsync(id);
            return NoContent();
        }


    }
}
