using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserService _userService { get; set; }

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("signup")]
        public async Task<ActionResult<UserRegistrationModel>> SignUpAsync([FromBody] UserRegistrationModel model)
        {
            await _userService.RegisterUserAsync(model);
            return Ok(model);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<LogInModel>> LogInAsync([FromBody] LogInModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            await _userService.LogInUserAsync(model);
            return Ok(model);
        }

        [HttpPost("logout")]
        public async  Task<ActionResult> LogOut()
        {
            await _userService.LogOut();
            return NoContent();
        }

    }

}
