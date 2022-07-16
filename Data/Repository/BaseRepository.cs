using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<X> : IBaseRepository<X> where X : BaseModel
    {
        protected readonly MyContext _myContext;
        private DbSet<X> _dataSet;
        public BaseRepository(MyContext context)
        {
            _myContext = context;
            _dataSet = _myContext.Set<X>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _myContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<X> InsertAsync(X model)
        {
            try
            {
                if (model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();

                model.Created = DateTime.Now;

                _dataSet.Add(model);
                await _myContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }

        public async Task<IEnumerable<X>> SelectAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<X> SelectDetailIdAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<X> UpdateAsync(X model)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == model.Id);

                if (result == null)
                    return null;

                model.Updated = DateTime.UtcNow;
                model.Created = result.Created;

                _myContext.Entry(result).CurrentValues.SetValues(model);
                await _myContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }
    }
}
