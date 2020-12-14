using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            var config = new MapperConfiguration(c => c.CreateMap<T, T>());

            //Mapper.Initialize(c => { c.CreateMap<T, T>();});
            var mapper = config.CreateMapper();
            List<T> result = mapper.Map<List<T>>(list);
            return result;
        }
        public static T MapToSameType<T>(T obj)
        {
            var config = new MapperConfiguration(c => c.CreateMap<T, T>());
            
            var mapper = config.CreateMapper();
            T result = mapper.Map<T>(obj);
            return result;
        }
    }
}
