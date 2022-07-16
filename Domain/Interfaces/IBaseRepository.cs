using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<X> where X : BaseModel
    {
        Task<bool> DeleteAsync(Guid id);
        Task<X> InsertAsync(X model);
        Task<IEnumerable<X>> SelectAllAsync();
        Task<X> SelectDetailIdAsync(Guid id);
        Task<X> UpdateAsync(X model);
    }
}
