using MediatR;
using Purkki.MediatorCacheExample.Database;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
	{
		private readonly ExampleContext context;

		public CreateCarCommandHandler(ExampleContext context)
		{
			this.context = context;
		}

		public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
		{
			var car = new Car
			{
				Make = request.Make,
				Model = request.Model
			};

			context.Cars.Add(car);
			await context.SaveChangesAsync(cancellationToken);

			return car;
		}
	}
}
