using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Interfaces;

namespace BLL.Services
{
    public class FriendService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FriendService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
