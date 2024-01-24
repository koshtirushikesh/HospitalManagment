using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class ResponseModel<T>
    {
        public bool IsSucces {  get; set; }
        public T Data { get; set; }
        public string message { get; set; } 
    }
}
