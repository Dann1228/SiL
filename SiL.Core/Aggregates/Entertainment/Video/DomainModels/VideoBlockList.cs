using SiL.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Aggregates.Entertainment.Video.DomainModels
{
    public class VideoBlockList
    {
        public string VideoID { get; set; }

        public QualityCode Quality { get; set; }

        public long TotalCount { get; set; }

        public IEnumerable<VideoStreamBlock> Blocks { get; set; }
    }
}
