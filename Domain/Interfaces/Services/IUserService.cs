using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> Delete(Guid id);
        Task<IEnumerable<UserModel>> Get();
        Task<UserModel> GetDetailId(Guid id);
        Task<UserModel> Post(UserModel userModel);
        Task<UserModel> Put(UserModel userModel);
    }
}
