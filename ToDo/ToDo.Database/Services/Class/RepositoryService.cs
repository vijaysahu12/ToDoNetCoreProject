using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Database.Table;

namespace ToDo.Database.Services
{
    public class RepositoryServiceService<T> : Interface.IRepository<T> where T : BaseEntity
    {
        readonly DbContext _dbContext;
        private DbSet<T> entities;
        public RepositoryServiceService(DbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public Task<T> Get(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetList()
        {
            var objList = new List<T>();
            try
            {
                return await entities.ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> Add(T entity)
        {
            if (entity == null) return false;
            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            if (Id <= 0) return false;

            var entity = await entities.FindAsync(Id);

            entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            entities.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
