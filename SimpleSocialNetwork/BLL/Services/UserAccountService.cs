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

            var mapped = _mapper.Map<UserAccount>(model);
            await _uow.UserAccountRepository.AddAsync(mapped);
            await _uow.SaveAsync();
            model.Id = mapped.Id;
        }

        public async Task UpdateAsync(UserAccountModel model)
        {
            if (model == null)
            {
                throw new SocialNetworkException("Model cannot be an empty", nameof(AddAsync));
            }
            var mapped = _mapper.Map<UserAccount>(model);
            await Task.Run(()=> _uow.UserAccountRepository.Update(mapped));
            await _uow.SaveAsync();
            model.Id = mapped.Id;
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            await _uow.UserAccountRepository.DeleteByIdAsync(modelId);
            await _uow.SaveAsync();
        }

        public IEnumerable<UserAccountModel> GetByFilter(UserAccountFilterSearchModel filter)
        {
            throw new NotImplementedException();
        }
    }
}
