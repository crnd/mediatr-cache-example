using MediatR;

namespace Purkki.MediatorCacheExample.Application.Infrastructure
{
	public interface IQuery<T> : IRequest<T> { }
}
