
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.BusinessLayer.Interface;
using ToDo.Database.Services;
using ToDo.Database.Services.Interface;
using ToDo.Entities;


namespace ToDo.BusinessLayer.Services
{
    public class ToDoService : IToDoService
    {
        readonly IRepository<Database.Database.Table.ToDo> _repository;
        public ToDoService(IRepository<Database.Database.Table.ToDo> repo)
        {
            _repository = repo;
        }

        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<List<ToDoModel>> GetList()
        {
            var objList = new List<ToDoModel>();
            try
            {
                var result = await _repository.GetList();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var itemData = new ToDoModel
                        {
                            Id = item.ToDoId,
                            content = item.Content,
                            Status = item.Status
                        };

                        objList.Add(itemData);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
                //ToDo: Log the error into database. 
            }
            return objList.OrderByDescending(x => x.Status).ToList();
        }

        public ToDoModel GetToDoItem()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveToDoItem(ToDoModel obj)
        {
            try
            {
                await _repository.Add(new Database.Database.Table.ToDo
                {
                    Content = obj.content,
                    ModifiedDate = System.DateTime.Now,
                    Status = true,
                });

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateToDoItem(ToDoModel obj)
        {
            try
            {
                await _repository.Update(new Database.Database.Table.ToDo
                {
                    Content = obj.content,
                    ModifiedDate = System.DateTime.Now,
                    Status = obj.Status,
                    ToDoId = obj.Id
                });

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        Task<ToDoModel> IToDoService.GetToDoItem()
        {
            throw new System.NotImplementedException();
        }
    }
}
