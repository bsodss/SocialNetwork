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
        private readonly IUnitOfWork _uow;
        public ValuesController(IUserService userService, IUnitOfWork uow)
        {
            _userService = userService;
            _uow = uow;
        }


        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<UserRegistrationModel>> GetUsers()
        {


            if (_uow?.UserAccountRepository != null)
            {


                return new ObjectResult((_uow?.UserAccountRepository.FindAllWithDetails().Select(s => new UserRegistrationModel()
                {
                    Id = s.Id,
                    Email = s.User.Email
                }).AsEnumerable()));
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
                await _uow.UserAccountRepository.AddAsync(new UserAccount()
                {
                    FirstName = "",
                    LastName = "",
                    User = user
                });
                await _uow.SaveAsync();
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
