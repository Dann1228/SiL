using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Core.Aggregates.Entertainment.Video.Services;
using SiL.Core.Constant;
using SiL.Lib.Base.Response;
using SiL.Lib.Base.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Story.Entertainment.Facades.Video
{
    public interface IVideoFacade
    {
        IVideoService VideoService { get; set; }

        /// <summary>
        /// 搜尋影片清單
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        SearchResponse<BaseSearchResult<VideoModel>> SearchVideoList(VideoSearchCondition condition);

        /// <summary>
        /// 搜尋加密影片清單
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        SearchResponse<BaseSearchResult<VideoModel>> SearchEncryptVideoList(string key, VideoSearchCondition condition);


        SearchResponse<VideoBlockList> GetDivideVideoBlockList(string vID, QualityCode quality);

        VideoStreamBlock GetDivideVideoBlock(string vID, QualityCode quality, int sort);
    }
}
