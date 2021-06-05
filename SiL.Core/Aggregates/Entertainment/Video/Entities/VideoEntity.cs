using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Aggregates.Entertainment.Video.Entities
{
    public class VideoEntity
    {
        public string ID { get; set; }

        /// <summary>
        /// 畫質
        /// </summary>
        public int Quality { get; set; }

        /// <summary>
        /// 季
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// 劇名
        /// </summary>
        public string DramaName { get; set; }

        /// <summary>
        /// 影集名
        /// </summary>
        public string EpisodeName { get; set; }

        /// <summary>
        /// 類型 - video、drama、anime
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string[] Classify { get; set; }

        /// <summary>
        /// 檔案路徑
        /// </summary>
        public string FilePath { get; set; }
    }
}
