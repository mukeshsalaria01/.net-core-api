﻿using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using NexusCanadaTech.Web.API.Core;

namespace NexusCanadaTech.Web.API.xUnit
{
    [DependsOn(typeof(WebApiCoreModule), typeof(AbpAutoMapperModule))]
    public class WebApiApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //We must declare mappings to be able to use AutoMapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                mapper.CreateMap<Core.DbModels.User, Core.DbModels.User>().ForMember(t => t.Id, opts => opts.MapFrom(d => d.Id));
            });
        }
    }
}
