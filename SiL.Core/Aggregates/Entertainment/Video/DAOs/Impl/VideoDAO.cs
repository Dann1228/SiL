using SiL.Core.Aggregates.Entertainment.Video.Entities;
using SiL.Core.Constant;
using SiL.Lib.Base.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SiL.Core.Aggregates.Entertainment.Video.DAOs.Impl
{
    public class VideoDAO : IVideoDAO
    {
        public List<VideoEntity> fakeVideoList = new List<VideoEntity>() { 
            new VideoEntity(){  ID = "1", Quality = 1080, DramaName = "test1", FilePath = @"D:\test\de\test.mp4"},
            new VideoEntity(){  ID = "1", Quality = 720, DramaName = "test1", FilePath = @"D:\test\de\test.mp4"},
            new VideoEntity(){  ID = "2", Quality = 720, DramaName = "test2"},
            new VideoEntity(){  ID = "3", Quality = 720, DramaName = "test3"},
            new VideoEntity(){  ID = "4", Quality = 720, DramaName = "test4"},
        };

        public BaseSearchResult<VideoEntity> SearchVideoList(VideoSearchConditionEntity condition)
        {
            throw new NotImplementedException();
        }

        public BaseSearchResult<VideoEntity> SearchEncryptVideoList(VideoSearchConditionEntity condition)
        {
            //查詢
            var result = from c in this.fakeVideoList
                         select c;

            //取得總筆數
            int totalCount = result.Count();

            //分頁筆數
            result = result.Skip(condition.Start).Take(condition.Length);

            return new BaseSearchResult<VideoEntity>(result.ToList(), condition.Start, condition.Length, totalCount);
        }

        public VideoEntity GetVideo(string vID, QualityCode quality)
        {
            VideoEntity result = null;

            result = (from c in this.fakeVideoList
                      where c.ID == vID &&  c.Quality == (int)quality
                      select c).FirstOrDefault();

            return result;
        }
    }
}
