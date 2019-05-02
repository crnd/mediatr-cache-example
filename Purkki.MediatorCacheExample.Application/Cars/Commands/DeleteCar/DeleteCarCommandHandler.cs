using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using Purkki.MediatorCacheExample.Database;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
	{
		private readonly ExampleContext _context;

		public DeleteCarCommandHandler(ExampleContext context)
		{
			_context = context;
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

			return Unit.Value;
		}
	}
}
