using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Project.MVC.Mappings
{
    public static class AutoMapperMaps
    {
        private static IMapper mapper = null;

        public static IMapper GetMapper()
        {
            return mapper;
        }

        public static void ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapping>();
            });

            mapper = config.CreateMapper();
        }

    }
}
