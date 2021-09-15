using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WepApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserFriends(string userId)
        {
            try
            {
                return new ObjectResult(await _friendService.GetUserFriends(userId));
            }
            catch (SocialNetworkException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}/friendrequests")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserFriendRequests(string userId)
        {
            return new ObjectResult(await _friendService.GetUserFriendsRequest(userId));
        }

        [HttpPost("{userId}/confirm/{friendId}")]
        public async Task<ActionResult> ConfirmFriendship(string userId, string friendId)
        {
            await _friendService.AcceptFriendRequest(userId, friendId);
            return Ok();
        }

        [HttpPost("{senderId}/add/{receiverId}")]
        public async Task<ActionResult> SendFriendRequest(string senderId, string receiverId)
        {
            await _friendService.SendFriendRequest(senderId, receiverId);
            return NoContent();
        }

        [HttpDelete("{userId}/deletes/{friendId}")]
        public async Task<ActionResult> DeleteFriendById(string userId, string friendId)
        {
            
            try
            {
                await _friendService.DeleteFriendAsync(userId, friendId);
                return NoContent();
            }
            catch (SocialNetworkException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
