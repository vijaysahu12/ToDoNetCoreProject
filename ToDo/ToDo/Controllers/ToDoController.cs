using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.BusinessLayer.Interface;
using ToDo.Entities;
using ToDo.Entities.Enum;

namespace ToDo.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDo")]
    public class ToDoController : Controller
    {
        readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        // GET api/values
        [HttpGet]
        public ResponseModel Get()
        {
            var objResponse = new ResponseModel();
            try
            {
                objResponse.Data = _toDoService.GetList().Result;
                objResponse.ResponseMessage = "success";
                objResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (System.Exception)
            {
                objResponse.Data = null;
                objResponse.ResponseMessage = "failed";
                objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return objResponse;
            //var data = new List<int>
            //{
            //    90,72
            //};
            //return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ResponseModel> PostAsync([FromBody]ToDoModel value)
        {
            var obj = new ResponseModel
            {
                Data = await _toDoService.SaveToDoItem(value),
                ResponseMessage = Messages.success,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return obj;
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ResponseModel> Put(int id, [FromBody]ToDoModel value)
        {
            var obj = new ResponseModel
            {
                Data = await _toDoService.UpdateToDoItem(value),
                ResponseMessage = Messages.success,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            var obj = new ResponseModel
            {
                Data = await _toDoService.Delete(id),
                ResponseMessage = Messages.success,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return obj;
        }
    }
}