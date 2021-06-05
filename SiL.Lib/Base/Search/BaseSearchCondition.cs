using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Base.Search
{
    public class BaseSearchCondition
    {
        /// <summary>
        /// 查詢的起始數
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 查詢的筆數
        /// </summary>
        public int Length { get; set; }
    }
}
