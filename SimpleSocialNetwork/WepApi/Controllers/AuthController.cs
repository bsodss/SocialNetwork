using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.Validation;
using Microsoft.AspNetCore.Authorization;

namespace WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("addrole")]
        public async Task<ActionResult> CreateRoleAsync(string name)
        {
            try
            {
                var result = await _userService.CreateRoleAsync(name);
                if (!result.Succeeded)
                {
                    return BadRequest();
                }

            }
            catch (SocialNetworkException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }


        [HttpPost("signup")]
        public async Task<ActionResult> SignUpAsync([FromBody] UserRegistrationModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _userService.RegisterUserAsync(model);

            if (result.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Problem(result.Errors.First().Description, null, 500);

        }

        [HttpPost("signin")]
        public async Task<ActionResult<LogInModel>> LogInAsync([FromBody] LogInModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _userService.LogInUserAsync(model);
            if (result.Succeeded)
            {
                return Ok();
            }

            return Unauthorized(model);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> LogOut()
        {

            try
            {
                await _userService.LogOut();
                return NoContent();
            }
            catch (SocialNetworkException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
