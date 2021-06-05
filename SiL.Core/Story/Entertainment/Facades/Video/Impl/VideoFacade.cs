using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Core.Aggregates.Entertainment.Video.Services;
using SiL.Core.Aggregates.Entertainment.Video.Services.Impl;
using SiL.Core.Constant;
using SiL.Lib.Base.Response;
using SiL.Lib.Base.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Core.Story.Entertainment.Facades.Video.Impl
{
    public class VideoFacade : IVideoFacade
    {
        public IVideoService VideoService { get; set; }

        public SearchResponse<BaseSearchResult<VideoModel>> SearchVideoList(VideoSearchCondition condition)
        {
            VideoService.SearchVideoList(new VideoSearchCondition());

            throw new NotImplementedException();
        }

        public SearchResponse<BaseSearchResult<VideoModel>> SearchEncryptVideoList(string key, VideoSearchCondition condition)
        {
            SearchResponse<BaseSearchResult<VideoModel>> result = null;
            try
            {
                var searchResult = VideoService.SearchEncryptVideoList(key, condition);
                if (searchResult != null)
                {
                    result = new SearchResponse<BaseSearchResult<VideoModel>>(true,"", null, searchResult);
                }
            }
            catch (Exception ex)
            {
                result = new SearchResponse<BaseSearchResult<VideoModel>>(false, new List<string>() { ConstValue.ERROR_MESSAGE_SEARCH_ERROR });
            }

            return result;
        }

        public SearchResponse<VideoBlockList> GetDivideVideoBlockList(string vID, QualityCode quality)
        {
            SearchResponse<VideoBlockList> result = null;
            try
            {
                var videoBlockList = VideoService.GetDivideVideoBlockList(vID, quality);
                if (videoBlockList != null)
                {
                    result = new SearchResponse<VideoBlockList>(true, "", null, videoBlockList);
                }
            }
            catch (Exception ex)
            {
                result = new SearchResponse<VideoBlockList>(false, new List<string>() { ConstValue.ERROR_MESSAGE_GET_DIVIDE_VIDEO_LIST_ERROR });
            }

            return result;
        }

        public VideoStreamBlock GetDivideVideoBlock(string vID, QualityCode quality, int sort)
        {
            VideoStreamBlock streamBlock = null;

            try
            {
                //取得所有的片段資料
                var videoBlocks = VideoService.DivideVideoBlockList(vID, quality);
                if (videoBlocks != null)
                {
                    streamBlock = videoBlocks.Where(x => x.Sort == sort).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                
            }

            return streamBlock;
        }
    }
}
