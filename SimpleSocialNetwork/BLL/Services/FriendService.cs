using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Validation;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FriendService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task SendFriendRequest(string senderId, string receiverId)
        {
            var sender = _uow.UserAccountRepository.FindAll().FirstOrDefault(i => i.Id == senderId);
            var receiver = _uow.UserAccountRepository.FindAll().FirstOrDefault(i => i.Id == receiverId);
            if (sender == null || receiver == null)
            {
                throw new SocialNetworkException("User with such id does not exist");
            }

            var friendRequest = new FriendRequest()
            {
                Id = Guid.NewGuid().ToString(),
                RequestBy = sender,
                RequestTo = receiver,
                IsConfirmed = false
            };
            await _uow.FriendRequestRepository.AddAsync(friendRequest);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserFriendsRequest(string userId)
        {

            var userFriendsFriendRequests = _uow.FriendRequestRepository.FindAllWithDetails().Where(r => r.RequestToId == userId);
            if (userFriendsFriendRequests == null)
            {
                throw new SocialNetworkException("User is not exist");
            }

            return _mapper.Map<IEnumerable<UserModel>>(userFriendsFriendRequests.Select(s => s.RequestBy));
        }

        public async Task AcceptFriendRequest(string receiverId, string senderId)
        {
            var friendRequest = _uow.FriendRequestRepository
                .FindAllWithDetails()
                .FirstOrDefault(i => i.RequestToId == receiverId && i.RequestById == senderId);
            if (friendRequest == null)
            {
                throw new SocialNetworkException("This friend request does not exist");
            }

            var friendship = new UserAccountFriend
            {
                FriendId = receiverId,
                UserAccountId = senderId
            };
            await _uow.UserAccountFriendRepository.AddAsync(friendship);
            _uow.FriendRequestRepository.Delete(friendRequest);
            await _uow.SaveAsync();
        }

        public async Task DeclineFriendRequest(string userId, string friendId)
        {
            var friendRequest = _uow.FriendRequestRepository
                .FindAllWithDetails()
                .FirstOrDefault(i => i.RequestToId == userId && i.RequestById == friendId);
            if (friendRequest == null)
            {
                throw new SocialNetworkException("This friend request does not exist");
            }

            _uow.FriendRequestRepository.Delete(friendRequest);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserFriends(string userId)
        {
            var user = await _uow.UserAccountRepository.GetByIdWithDetailsAsync(userId);
            if (user == null)
            {
                throw new SocialNetworkException("User is not exist");
            }

            var userFriendsIds = user.FriendsAddedByMe.Select(s => s.FriendId)
                .Concat(user.FriendsWhoAddedMe.Select(s => s.UserAccountId));
            var userFriends = _uow.UserAccountRepository.FindAllWithDetails().Where(i => userFriendsIds.Contains(i.Id));
            return _mapper.Map<IEnumerable<UserModel>>(userFriends);
        }


        public async Task DeleteFriendAsync(string userId, string friendId)
        {
            var friendTable = _uow.UserAccountFriendRepository.FindAll()
                .FirstOrDefault(i =>
                    (i.UserAccountId == userId && i.FriendId == friendId)
                    || (i.FriendId == userId && i.UserAccountId == friendId));
            if (friendTable == null)
            {
                throw new SocialNetworkException($"Friendship between {userId} and {friendId} does not exist!");
            }
            _uow.UserAccountFriendRepository.Delete(friendTable);
            await _uow.SaveAsync();
        }
    }
}
