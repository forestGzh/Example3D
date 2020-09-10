using System;
using Autofac;
using Example3D.Accounts.Application.Queries;
using Example3D.Accounts.Domain.AggregatesModel.AccountAggregate;
using Example3D.Accounts.Infrastructure.Repositories;

namespace Example3D.Accounts.API.Infrastructure.AutofacModules
{
    /// <summary>
    /// 自定义接口相关服务的注册
    /// </summary>
    public class ApplicationModule : Autofac.Module
    {

        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountQueries>()
                .As<IAccountQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountRepository>()
                .As<IAccountRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
