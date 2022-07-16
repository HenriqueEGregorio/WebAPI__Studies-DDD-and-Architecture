using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IBaseRepository<UserModel> _baseRepository;

        public UserService(IBaseRepository<UserModel> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _baseRepository.SelectAllAsync();
        }

        public async Task<UserModel> GetDetailId(Guid id)
        {
            return await _baseRepository.SelectDetailIdAsync(id);
        }

        public async Task<UserModel> Post(UserModel userModel)
        {
            return await _baseRepository.InsertAsync(userModel);
        }

        public async Task<UserModel> Put(UserModel userModel)
        {
            return await _baseRepository.UpdateAsync(userModel);
        }
    }
}
