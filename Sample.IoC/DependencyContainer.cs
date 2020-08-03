using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;
using Sample.Services.Dto;

namespace Sample.IoC
{
    class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
