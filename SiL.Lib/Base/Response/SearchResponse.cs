using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Base.Response
{
    public class SearchResponse<T> : CommandResponse
    {        
        /// <summary>
        /// 資料本題
        /// </summary>
        public T? Data { set; get; }


        public SearchResponse(T data) : base()
        {
            Data = data;
        }

        public SearchResponse(bool isSuccess, string message, List<string> errors, T? data = default) : base(isSuccess, message, errors)
        {
            Data = data;
        }

        public SearchResponse(bool isSuccess, List<string> errors = default!, T? data = default) : this(isSuccess,
                isSuccess ? MessageSuccess : MessageFail, errors)
        {
            Data = data;
        }
    }
}
