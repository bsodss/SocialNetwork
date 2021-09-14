using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BLL.Interfaces
{
    public interface IFriendService
    {
        public Task SendFriendRequest(string senderId, string receiverId);

        public Task AcceptFriendRequest(string receiverId, string senderId);
        public Task DeclineFriendRequest(string userId, string friendId);

        public Task<IEnumerable<UserAccountModel>> GetUserFriendsRequest(string userId);
        public Task<IEnumerable<UserAccountModel>> GetUserFriends(string userId);

        public void ConfirmFriendship(string userId, string friendId);
        public Task DeleteFriendAsync(string friendId);
    }
}
