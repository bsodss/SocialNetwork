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
    public class ValuesController : ControllerBase
    {


        private readonly IUserService _userService;
        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<UserRegistrationModel>> GetUsers()
        {
            if (_userService?.userManager?.Users != null)
            {


                return new ObjectResult(_userService.userManager.Users.Select(s => new UserRegistrationModel()
                {
                    Id = s.Id,
                    Email = s.Email
                }).AsEnumerable());
            }

            return BadRequest();
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Register([FromBody] UserRegistrationModel model)
        {
            if (model == null)
                return NotFound();
            User user = new User()
            {
                Email = model.Email,
                UserName = model.Email,
            };
            var result = await _userService.userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                return NoContent();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }


    }

    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplited { get; set; }
    }
}
