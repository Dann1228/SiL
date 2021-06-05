using SiL.Lib.Base.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Aggregates.Entertainment.Video.Entities
{
    public class VideoSearchConditionEntity : BaseSearchCondition
    {
        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 類型
        /// </summary>
        public string[] Type { get; set; }
    }
}
