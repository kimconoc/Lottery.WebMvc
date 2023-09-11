using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.DoMain.Models.BaseModel
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public ResponseMessage Message { get; set; }
    }
    public class ResponseMessage
    {
        public string ViMessage { get; set; }
        public string EnMessage { get; set; }
    }
}
