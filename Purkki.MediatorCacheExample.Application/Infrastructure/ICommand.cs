using MediatR;

namespace Purkki.MediatorCacheExample.Application.Infrastructure
{
	public interface ICommand : IRequest { }
	public interface ICommand<T> : IRequest<T> { }
}
