using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork UoW, IMapper Mapper)
        {
            _uow = UoW;
            _mapper = Mapper;
        }


        public IEnumerable<UserModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserModel>>( _uow.UserRepository.FindAllWithDetails().AsEnumerable());
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return  _mapper.Map<UserModel>(await _uow.UserRepository.GetByIdWithDetailsAsync(id));
        }

        public async Task AddAsync(UserModel model)
        {
            await _uow.UserRepository.AddAsync(_mapper.Map<User>(model));
        }

        public async Task UpdateAsync(UserModel model)
        {
            await Task.Run(()=> _uow.UserRepository.Update(_mapper.Map<User>(model)));
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.UserRepository.DeleteByIdAsync(modelId);
        }
    }
}
