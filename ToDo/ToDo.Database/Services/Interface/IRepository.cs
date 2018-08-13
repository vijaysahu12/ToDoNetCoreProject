using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo.Database.Services.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(T entity);
        Task<List<T>> GetList();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int Id);
    }
}
