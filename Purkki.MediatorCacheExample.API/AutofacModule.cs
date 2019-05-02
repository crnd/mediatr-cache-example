using Autofac;
using MediatR;
using Purkki.MediatorCacheExample.Application.Infrastructure.Behaviors;

namespace Purkki.MediatorCacheExample.API
{
	public class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterGeneric(typeof(QueryCachingBehavior<,>))
				.As(typeof(IPipelineBehavior<,>))
				.InstancePerLifetimeScope();
		}
	}
}
