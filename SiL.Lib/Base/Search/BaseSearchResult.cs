using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Base.Search
{
    public class BaseSearchResult<T>
    {
        public List<T> Result { get; set; }

        public int Length { get; set; }

        public int Start { get; set; }


        public int TotalCount { get; set; }

        public BaseSearchResult(List<T> result, int start, int length, int totalCount)
        {
            Result = result;
            this.Start = start;
            this.Length = length;
            this.TotalCount = totalCount;
        }
    }
}
