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
    public class UserAccountService:IUserAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserAccountService(IUnitOfWork UoW, IMapper Mapper)
        {
            _uow = UoW;
            _mapper = Mapper;
            
        }


        public IEnumerable<UserAccountModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserAccountModel>>( _uow.UserAccountRepository.FindAllWithDetails().AsEnumerable());
        }

        public async Task<UserAccountModel> GetByIdAsync(string id)
        {
            return  _mapper.Map<UserAccountModel>(await _uow.UserAccountRepository.GetByIdWithDetailsAsync(id));
        }

        public async Task AddAsync(UserAccountModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("Model cannot be an empty", nameof(AddAsync));
            }

            await _uow.UserAccountRepository.AddAsync(_mapper.Map<UserAccount>(model));
        }

        public async Task UpdateAsync(UserAccountModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("Model cannot be an empty", nameof(AddAsync));
            }
            await Task.Run(()=> _uow.UserAccountRepository.Update(_mapper.Map<UserAccount>(model)));
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            await _uow.UserAccountRepository.DeleteByIdAsync(modelId);
        }

        public IEnumerable<UserAccountModel> GetByFilter(UserAccountFilterSearchModel filter)
        {
            return _mapper.Map<IEnumerable<UserAccountModel>>(_uow.UserAccountRepository.FindAll().Where(i => i.IsMale==filter.IsMale).AsEnumerable());
        }
    }
}
