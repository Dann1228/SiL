using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiL.BackEnd.Models.ViewModel.Video;
using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Core.Story.Entertainment.Facades.Video;
using SiL.Lib.Utils.MapperUtil;
using SiL.Web.Models.ViewModel.Base;
using SiL.Web.Models.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SiL.BackEnd.Controllers.Entertainment
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public IVideoFacade VideoFacade { get; set; }

        /// <summary>
        /// 取得加密影片清單
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cond"></param>
        /// <returns></returns>
        [HttpPost]
        public RxjsResponse<List<VideoVM>> SearchEncryptList(string key, VideoSearchConditionVM cond)
        {
            List<VideoVM> videos = null;
            var result = this.VideoFacade.SearchEncryptVideoList(key, MapperUtil.Map<VideoSearchConditionVM, VideoSearchCondition>(cond));
            if (result.IsSuccess)
            {
                videos = MapperUtil.MapList<VideoModel, VideoVM>(result.Data.Result);
            }

            return new RxjsResponse<List<VideoVM>>() { IsSuccess = result.IsSuccess, Data = videos, Message = result.Message };
        }

        /// <summary>
        /// 取得影片的所有讀取片段
        /// </summary>
        /// <param name="vID"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet]
        public RxjsResponse<VideoBlockListVM> GetBlockList(string vID, Core.Constant.QualityCode q)
        {
            VideoBlockListVM blockList = null;
            var result = this.VideoFacade.GetDivideVideoBlockList(vID, q);
            if (result.IsSuccess)
            {
                blockList = MapperUtil.Map<VideoBlockList, VideoBlockListVM>(result.Data);
            }

            return new RxjsResponse<VideoBlockListVM>() { IsSuccess = result.IsSuccess, Data = blockList, Message = result.Message };
        }

        [HttpGet]
        public IActionResult GetVideo(string vID, Core.Constant.QualityCode q, int s)
        {
            var videoBlock = this.VideoFacade.GetDivideVideoBlock(vID, q, s);
            if (videoBlock != null)
            {
                //return File(videoBlock.Binary, "video/mp4");
                return File(videoBlock.Binary, "application/octet-stream");
                //return File(@"D:\test\de\test.mp4", "video/mp4");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult SampleVideoStream()
        {
            var filePath = @"D:\test\de\test-2.mp4";

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.jpg
                FileName = Path.GetFileName(filePath),
                // set to true when it is a image
                Inline = true
            };
            //Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("Accept-Ranges", "bytes");
            var fs = System.IO.File.ReadAllBytes(filePath);
            return File(fs, "video/mp4");
        }
    }
}
