using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;

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


        [HttpGet("{id}/friends")]
        public async Task<ActionResult<IEnumerable<UserAccountModel>>> GetUserFriends(string userId)
        {
            return new ObjectResult(await _friendService.GetUserFriends(userId));
        }

        [HttpGet("{userId}/friendrequests")]
        public async Task<ActionResult<IEnumerable<UserAccountModel>>> GetUserFriendRequests(string userId)
        {
            return new ObjectResult(await _friendService.GetUserFriendsRequest(userId));
        }

        [HttpPost("{senderId}/add/{receiverId}")]
        public async Task<ActionResult> SendFriendRequest(string senderId, string receiverId)
        {
            await _friendService.SendFriendRequest(senderId, receiverId);
            return NoContent();
        }

    }
}
