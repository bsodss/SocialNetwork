using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserRegistrationModel>> SignUpAsync([FromBody] UserRegistrationModel model)
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

            return BadRequest(model);
            //return Problem(result.Errors.First().Description, null, 500);

        }

        [HttpPost("signin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<LogInModel>> LogInAsync([FromBody] LogInModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _userService.LogInUserAsync(model);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(model);
        }

        [Authorize]
        [HttpPost("logout")]
        public async  Task<ActionResult> LogOut()
        {
         
            await _userService.LogOut();
            return NoContent();
        }

    }

}
