using SiL.Core.Aggregates.Entertainment.Video.DAOs;
using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Core.Constant;
using SiL.Lib.Base.Search;
using System.Collections.Generic;
using System.IO;

namespace SiL.Core.Aggregates.Entertainment.Video.Services
{
    public interface IVideoService
    {
        IVideoDAO VideoDAO { get; set; }

        /// <summary>
        /// 搜尋影片清單
        /// </summary>
        /// <returns></returns>
        BaseSearchResult<VideoModel> SearchVideoList(VideoSearchCondition condition);

        /// <summary>
        /// 搜尋加密影片清單
        /// </summary>
        /// <param name="condition"></param>
        /// <param name=""></param>
        /// <returns></returns>
        BaseSearchResult<VideoModel> SearchEncryptVideoList(string key, VideoSearchCondition condition);

        /// <summary>
        /// 取分段影片資料清單
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        IEnumerable<VideoStreamBlock> DivideVideoBlockList(Stream stream);

        /// <summary>
        /// 取分段影片資料清單
        ///     功能說明 : 讀取影片，並將依據區塊大小切成片段，回傳所有片段清單
        /// </summary>
        /// <param name="vID"></param>
        /// <returns></returns>
        IEnumerable<VideoStreamBlock> DivideVideoBlockList(string vID, QualityCode quality);

        VideoBlockList GetDivideVideoBlockList(string vID, QualityCode quality);
    }
}
