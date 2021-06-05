using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Aggregates.Entertainment.Video.DomainModels
{
    public class VideoStreamBlock
    {
        public string VideoID { get; set; }

        public int Sort { get; set; }

        public byte[] Binary { get; set; }

        public int Length { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public StreamDetail VideoDetail { get; set; }
    }
}
   