using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.TestBase;

namespace NexusCanadaTech.Web.API.xUnit
{
    [DependsOn(
       // typeof(SimpleTaskSystemDataModule),
        typeof(WebApiApplicationModule),
        typeof(AbpTestBaseModule)
    )]

    public class WebApiTestModule : AbpModule
    {

    }
}
