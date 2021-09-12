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
        public void SendFriendRequest(string senderId, string receiverId);

        public void AcceptFriendRequest();
        public void DiscardFriendRequest();

        public Task<IEnumerable<UserAccountModel>> GetUserFriends(string userId);

        public void ConfirmFriendship(string userId, string friendId);
        public Task DeleteFriendAsync(string friendId);
    }
}
