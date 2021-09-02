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
            CreateMap<User, UserModel>()
                .ForMember(m => m.FriendRequestReceivedIds,
                    c => c.MapFrom(f => f.FriendRequestReceived.Select(request => request.Id)))
                .ForMember(dest=>dest.FriendRequestSentIds, 
                    map=> map.MapFrom(request=> request.FriendRequestSent.Select(s=>s.Id)))
                .ForMember(dest=>dest.PostsIds,
                    map=> map.MapFrom(req=> req.Posts.Select(s=>s.Id))).ReverseMap();
        }
    }
}
