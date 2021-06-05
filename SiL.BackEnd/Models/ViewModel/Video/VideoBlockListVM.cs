using SiL.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiL.BackEnd.Models.ViewModel.Video
{
    public class VideoBlockListVM
    {
        public string VideoID { get; set; }

        public QualityCode Quality { get; set; }

        public int TotalCount { get; set; }
    }
}
