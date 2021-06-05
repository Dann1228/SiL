using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiL.Web.Models.ViewModel.Base
{
    public class RxjsResponse<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } 

        public T Data { get; set; }
    }
}
