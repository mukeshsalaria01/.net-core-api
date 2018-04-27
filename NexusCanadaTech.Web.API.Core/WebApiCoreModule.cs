using System.Reflection;
using Abp.Modules;

namespace NexusCanadaTech.Web.API.Core
{
   public class WebApiCoreModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
