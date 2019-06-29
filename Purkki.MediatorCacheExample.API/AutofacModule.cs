using Autofac;
using MediatR;
using Purkki.MediatorCacheExample.Application.Infrastructure;
using Purkki.MediatorCacheExample.Application.Infrastructure.Behaviors;

namespace Purkki.MediatorCacheExample.API
{
	public class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<Mediator>()
				.As<IMediator>()
				.InstancePerLifetimeScope();

			builder
				.Register<ServiceFactory>(context =>
				{
					var c = context.Resolve<IComponentContext>();
					return t => c.Resolve(t);
				});

			builder
				.RegisterGeneric(typeof(QueryCachingBehavior<,>))
				.As(typeof(IPipelineBehavior<,>))
				.InstancePerDependency();

			builder
				.RegisterGeneric(typeof(CacheClearingBehavior<,>))
				.As(typeof(IPipelineBehavior<,>))
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(typeof(ICommand<>).Assembly)
				.AsImplementedInterfaces();
		}
	}
}
