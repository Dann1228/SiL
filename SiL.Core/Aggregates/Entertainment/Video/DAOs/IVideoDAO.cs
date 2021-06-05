using SiL.Core.Aggregates.Entertainment.Video.Entities;
using SiL.Core.Constant;
using SiL.Lib.Base.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiL.Core.Aggregates.Entertainment.Video.DAOs
{
    public interface IVideoDAO
    {
        VideoEntity GetVideo(string vID, QualityCode quality);

        BaseSearchResult<VideoEntity> SearchVideoList(VideoSearchConditionEntity condition);

        BaseSearchResult<VideoEntity> SearchEncryptVideoList(VideoSearchConditionEntity condition);
    }
}
