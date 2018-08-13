using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Entities
{
    public class ResponseModel
    {
        public dynamic Data { get; set; }
        public string ResponseMessage { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
    }
}
