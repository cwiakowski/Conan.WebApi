using AutoMapper;
using Conan.Common.DTO;
using Conan.Data.Models;

namespace Conan.Common.Services
{
    public class MapperService
    {
        public static IMapper GetMapperInstance()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                //	            config.AllowNullCollections = true;
                config.CreateMap<Message, MessageDTO>();
                
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}