using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Utils.MapperUtil
{
    public class MapperUtil
    {
        /// <summary>
        /// 使用客製化的 mapper 做物件欄位的對應
        /// 例:
        ///     cfg => {
        ///         cfg.CreateMapper<來源, 目標>().ForMember(x => 目標欄位, y => y.MapFrom(s => 來源欄位))
        ///     };
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IMapper CreateMapper(Action<IMapperConfigurationExpression> config)
        {
            var mapperConfig = new MapperConfiguration(config);
            IMapper mapper = new Mapper(mapperConfig);
            return mapper;
        }

        /// <summary>
        /// 將 source 物件從 T1 轉成 T2 的類別
        /// </summary>
        /// <typeparam name="T1">source的物件類別</typeparam>
        /// <typeparam name="T2">要轉成的]物件類別</typeparam>
        /// <param name="source">要轉的資料</param>
        /// <returns></returns>
        public static T2 Map<T1, T2>(T1 source)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<T1, T2>();
            });
            IMapper mapper = new Mapper(mapperConfig);

            //把T1轉成T2
            return mapper.Map<T1, T2>(source);
        }

        /// <summary>
        /// 將 source 物件從 T1 轉成 T2 的類別 List
        /// </summary>
        /// <typeparam name="T1">source的物件類別</typeparam>
        /// <typeparam name="T2">要轉成的]物件類別</typeparam>
        /// <param name="source">要轉的資料</param>
        /// <returns></returns>
        public static List<T2> MapList<T1, T2>(List<T1> source)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<T1, T2>();
            });
            IMapper mapper = new Mapper(mapperConfig);

            //把T1 List 轉成 T2 List
            return mapper.Map<List<T1>, List<T2>>(source);
        }
    }
}
