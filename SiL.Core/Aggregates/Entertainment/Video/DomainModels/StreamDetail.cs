using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Aggregates.Entertainment.Video.DomainModels
{
    public class StreamNote
    {
        public string ID { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime StreamTime { get; set; }
    }

    public class StreamBulletScreen
    {
        public string ID { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime StreamTime { get; set; }
    }

    public class StreamDetail
    {
        public string ID { get; set; }

        public List<StreamNote> Notes { get; set; }

        public List<StreamBulletScreen> BulletScreens { get; set; }
    }
}
