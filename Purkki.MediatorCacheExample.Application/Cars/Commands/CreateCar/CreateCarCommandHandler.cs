using MediatR;
using Purkki.MediatorCacheExample.Application.Cars.Notifications;
using Purkki.MediatorCacheExample.Database;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
	{
		private readonly ExampleContext _context;
		private readonly IMediator _mediator;

		public CreateCarCommandHandler(ExampleContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
		{
			var car = new Car
			{
				Make = request.Make,
				Model = request.Model
			};

			_context.Cars.Add(car);
			await _context.SaveChangesAsync(cancellationToken);

			await _mediator.Publish(new ClearCarsCacheEntryNotification(), cancellationToken);

			return car.Id;
		}
	}
}
