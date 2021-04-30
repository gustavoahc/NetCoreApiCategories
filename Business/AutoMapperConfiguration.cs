using AutoMapper;
using Business.Models;
using Entities.Entities;

namespace Business
{
    public static class AutoMapperConfiguration
    {
        private static IMapper _mapperProperty;

        public static IMapper GetMapperProperty()
        {
            return _mapperProperty;
        }

        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryAddDto>().ReverseMap();
            });

            _mapperProperty = new Mapper(config);
        }
    }
}
