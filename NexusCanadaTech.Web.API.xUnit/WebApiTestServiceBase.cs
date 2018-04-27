using System;
using System.Data.Common;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;
using NexusCanadaTech.Web.API.Repositories;
using NexusCanadaTech.Web.API.xUnit.InitialData;

namespace NexusCanadaTech.Web.API.xUnit
{
    /// <summary>
    /// This is base class for all our test classes.
    /// It prepares ABP system, modules and a fake, in-memory database.
    /// Seeds database with initial data (<see cref="WebApiInitialDataBuilder"/>).
    /// Provides methods to easily work with DbContext.
    /// </summary>
    public abstract class WebApiTestServiceBase : AbpIntegratedTestBase<WebApiTestModule>
    {
        protected WebApiTestServiceBase()
        {
            //Seed initial data
            UsingDbContext(context => new WebApiInitialDataBuilder().Build(context));
        }

        protected override void PreInitialize()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
            );

            base.PreInitialize();
        }

        public void UsingDbContext(Action<NexusRepository> action)
        {
            using (var context = LocalIocManager.Resolve<NexusRepository>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<NexusRepository, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<NexusRepository>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}


