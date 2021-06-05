using SiL.Lib.Base.Response;
using System;
using System.Collections.Generic;
using System.Text;
using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Lib.Base.Search;
using System.Reflection;
using SiL.Core.Aggregates.Entertainment.Video.DAOs;
using SiL.Lib.Utils.MapperUtil;
using SiL.Core.Aggregates.Entertainment.Video.Entities;
using System.Linq;
using AutoMapper;
using SiL.Lib.Utils.EncryptUtil;
using System.IO;
using SiL.Core.Constant;

namespace SiL.Core.Aggregates.Entertainment.Video.Services.Impl
{
    public class VideoService : IVideoService
    {
        public IVideoDAO VideoDAO { get; set; }
        private int _chunkLength { get; set; } = 512000; //500KB

        public BaseSearchResult<VideoModel> SearchVideoList(VideoSearchCondition condition)
        {
            throw new NotImplementedException();
        }

        public BaseSearchResult<VideoModel> SearchEncryptVideoList(string key, VideoSearchCondition condition)
        {
            //取得清單資料
            var data = this.VideoDAO.SearchEncryptVideoList(MapperUtil.Map<VideoSearchCondition, VideoSearchConditionEntity>(condition));

            //清單資料解密
            IMapper mapperVIPVideo = MapperUtil.CreateMapper(cfg =>
            {
                cfg.CreateMap<VideoEntity, VideoModel>().ForMember(x => x.DramaName, y => y.MapFrom(
                    s => Encoding.Unicode.GetString(EncryptUtil.AESDecrypt(Encoding.Unicode.GetBytes(s.DramaName), key)).Replace("\0", string.Empty)));
            });

            var videoList = data.Result.Select(x => mapperVIPVideo.Map<VideoModel>(x)).ToList();

            return new BaseSearchResult<VideoModel>(videoList, data.Start, data.Length, data.TotalCount);
        }

        public IEnumerable<VideoStreamBlock> DivideVideoBlockList(Stream stream)
        {
            List<VideoStreamBlock> streamBlocks = new List<VideoStreamBlock>();

            if (stream != null)
            {
                //計算總共片段的數量
                long chunkTotalNumber = (stream.Length / this._chunkLength);

                for (int i = 0; i <= chunkTotalNumber; i++)
                {
                    byte[] chunkByte;
                    if (i == chunkTotalNumber)
                    {
                        chunkByte = new byte[stream.Length - (this._chunkLength * i)]; //計算最後片段長度 (總長度 - (長度*已完成區段))
                    }
                    else
                    {
                        chunkByte = new byte[this._chunkLength];
                    }

                    //取得片段資料流
                    stream.Read(chunkByte, 0, chunkByte.Length);

                    streamBlocks.Add(new VideoStreamBlock()
                    {
                        Sort = i,
                        Binary = chunkByte,
                        Length = chunkByte.Length
                    });
                }
            }

            return streamBlocks;
        }

        public IEnumerable<VideoStreamBlock> DivideVideoBlockList(string vID, QualityCode quality)
        {
            IEnumerable<VideoStreamBlock> streamBlocks = null;

            //取得影片紀錄資料
            var videoInfo = this.VideoDAO.GetVideo(vID, quality);

            //分段影片資料流
            if (videoInfo != null && File.Exists(videoInfo.FilePath))
            {
                using (FileStream fileStream = File.OpenRead(videoInfo.FilePath))
                {
                    streamBlocks = this.DivideVideoBlockList(fileStream);

                    //設定影片資料
                    streamBlocks.ToList().ForEach(x => x.VideoID = vID);
                }
            }

            return streamBlocks;
        }

        public VideoBlockList GetDivideVideoBlockList(string vID, QualityCode quality)
        {
            VideoBlockList videoBlockList = new VideoBlockList() { VideoID = vID, Quality = quality };

            //取得影片紀錄資料
            var videoInfo = this.VideoDAO.GetVideo(vID, quality);

            //分段影片資料流
            if (videoInfo != null && File.Exists(videoInfo.FilePath))
            {
                videoBlockList.Blocks = new List<VideoStreamBlock>();

                using (FileStream stream = File.OpenRead(videoInfo.FilePath))
                {
                    //計算總共片段的數量
                    videoBlockList.TotalCount = (stream.Length / this._chunkLength);

                    for (int i = 0; i <= videoBlockList.TotalCount; i++)
                    {
                        byte[] chunkByte;
                        if (i == videoBlockList.TotalCount)
                        {
                            chunkByte = new byte[stream.Length - (this._chunkLength * i)]; //計算最後片段長度 (總長度 - (長度*已完成區段))
                        }
                        else
                        {
                            chunkByte = new byte[this._chunkLength];
                        }

                        videoBlockList.Blocks.ToList().Add(new VideoStreamBlock()
                        {
                            Sort = i,
                            Length = chunkByte.Length
                        });
                    }
                }
            }

            return videoBlockList;
        }
    }
}
