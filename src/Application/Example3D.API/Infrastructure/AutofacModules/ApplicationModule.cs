using System;
using Autofac;
using Example3D.Application.Queries;
using Example3D.Domain.AggregatesModel.BookAggregate;
using Example3D.Infrastructure.Repositories;

namespace Example3D.API.Infrastructure.AutofacModules
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
            builder.RegisterType<BookQueries>()
                .As<IBookQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
