using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;
using Sample.Services.Dto;
using Sample.Services.Interfaces;

namespace Sample.IoC
{
    class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
