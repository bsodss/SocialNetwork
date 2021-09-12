using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserAccount, UserAccountModel>()
                .ForMember(m => m.FriendRequestReceivedIds,
                    c => c.MapFrom(f => f.FriendRequestReceived.Select(request => request.Id)))
                .ForMember(dest => dest.FriendRequestSentIds,
                    map => map.MapFrom(req => req.FriendRequestSent.Select(s => s.Id)))
                .ForMember(dest => dest.PostsIds,
                    map => map.MapFrom(req => req.Posts.Select(s => s.Id)))
                .ForMember(dest => dest.UserAccountFriendsIds,
                    map => map.MapFrom(req => Enumerable.Concat(req.FriendsAddedByMe.Select(s => s.FriendId),
                        req.FriendsWhoAddedMe.Select(s => s.UserAccountId)))).ReverseMap();


        }
    }
}
