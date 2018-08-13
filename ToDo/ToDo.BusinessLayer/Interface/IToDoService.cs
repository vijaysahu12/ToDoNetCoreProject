using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.BusinessLayer.Interface
{
    public interface IToDoService
    {
        Task<ToDoModel> GetToDoItem();
        Task<List<ToDoModel>> GetList();
        Task<bool> SaveToDoItem(ToDoModel obj);
        Task<bool> UpdateToDoItem(ToDoModel obj);
        Task<bool> Delete(int id);
    }
}
