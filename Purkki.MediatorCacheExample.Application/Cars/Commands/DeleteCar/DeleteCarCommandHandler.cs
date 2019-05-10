using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Application.Cars.Notifications;
using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using Purkki.MediatorCacheExample.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
	{
		private readonly ExampleContext _context;
		private readonly IMediator _mediator;

		public DeleteCarCommandHandler(ExampleContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
		{
			var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
			if (car == null)
			{
				throw new NotFoundException(nameof(car), request.Id.ToString());
			}

			_context.Cars.Remove(car);
			await _context.SaveChangesAsync(cancellationToken);

			await _mediator.Publish(new ClearCarsCacheEntryNotification(), cancellationToken);

			return Unit.Value;
		}
	}
}
