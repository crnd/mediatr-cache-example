using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using Purkki.MediatorCacheExample.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
	{
		private readonly ExampleContext context;

		public DeleteCarCommandHandler(ExampleContext context)
		{
			this.context = context;
		}

		public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
		{
			var car = await context.Cars.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
			if (car == null)
			{
				throw new NotFoundException(nameof(car), request.Id.ToString());
			}

			context.Cars.Remove(car);
			await context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
