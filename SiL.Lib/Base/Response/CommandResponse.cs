using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Base.Response
{
    public class CommandResponse
    {
        public const string MessageSuccess = "執行成功";
        public const string MessageFail = "執行失敗";

        // 訊息碼：成功
        public const string CodeSuccess = "000";
        public const string CodeFail = "001";

        /// <summary>
        /// 成功否
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// 回應訊息 預設成功
        /// </summary>
        public string Message { get; set; } = MessageSuccess;

        /// <summary>
        /// 放置錯誤訊息
        /// </SUMMARY>
        public List<string> Errors { get; set; }

        public CommandResponse(bool isSuccess, string message, List<string> errors = default!)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors;
        }

        public CommandResponse(bool isSuccess, List<string> errors = default!) : this(isSuccess,
            isSuccess ? MessageSuccess : MessageFail, errors)
        {

        }

        public CommandResponse() : this(isSuccess: true, message: MessageSuccess, errors: new List<string>())
        {
        }

    }
}
