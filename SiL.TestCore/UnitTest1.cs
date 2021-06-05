using NUnit.Framework;
using SiL.Core.Aggregates.Entertainment.Video.DAOs;
using SiL.Core.Aggregates.Entertainment.Video.DAOs.Impl;
using SiL.Core.Aggregates.Entertainment.Video.DomainModels;
using SiL.Core.Aggregates.Entertainment.Video.Entities;
using SiL.Core.Aggregates.Entertainment.Video.Services;
using SiL.Core.Aggregates.Entertainment.Video.Services.Impl;
using SiL.Lib.Base.Search;
using SiL.Lib.Utils.EncryptUtil;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SiL.TestCore
{
    public class Tests
    {
        private string _videoFilePath = @"D:\test\de\test.mp4";


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Encrypt_Name_Should_Be_Decrypt_Success()
        {
            //asset
            List<string> oriNameList = new List<string>();
            string key = "daniel4test";
            VideoDAO videoDAO = new VideoDAO();
            videoDAO.fakeVideoList.ForEach(x => {
                oriNameList.Add(x.DramaName);
                x.DramaName = Encoding.Unicode.GetString(EncryptUtil.AESEncrypt(Encoding.Unicode.GetBytes(x.DramaName), key)); //¥[±K
            });
            IVideoService VideoService = new VideoService();
            VideoService.VideoDAO = videoDAO;

            //act
            var data= VideoService.SearchEncryptVideoList(key, new VideoSearchCondition() { Start = 0, Length = 10});

            //assert
            Assert.AreEqual(4, data.TotalCount);
            Assert.AreEqual(oriNameList[0], data.Result[0].DramaName);
            Assert.AreEqual(oriNameList[1], data.Result[1].DramaName);
            Assert.AreEqual(oriNameList[2], data.Result[2].DramaName);
            Assert.AreEqual(oriNameList[3], data.Result[3].DramaName);
        }

        [Test]
        public void Get_Divide_Video_Block_List_With_Stream_Should_Be_Success()
        {
            //asset 
            FileStream fs = null;
            IVideoService VideoService = new VideoService();
            fs = File.OpenRead(this._videoFilePath);

            //act
            var result = VideoService.DivideVideoBlockList(fs).ToList();
            var totalLength = result.Sum(x => x.Length);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result.First().Binary);
            Assert.AreEqual(fs.Length, totalLength);
        }

        [Test]
        public void Get_Divide_Video_Block_List_With_VideoID_Should_Be_Success()
        {
            //asset 
            string vID = "1";
            IVideoService VideoService = new VideoService();
            VideoDAO videoDAO = new VideoDAO();
            videoDAO.fakeVideoList = new List<VideoEntity>() 
            {
                new VideoEntity(){ ID = vID, FilePath = _videoFilePath, DramaName = "test" },
            };
            VideoService.VideoDAO = videoDAO;

            //act
            var result = VideoService.DivideVideoBlockList(vID).ToList();

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(vID, result.First().VideoID);
            Assert.IsNotNull(result.First().Binary);
        }
    }
}