using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Purkki.MediatorCacheExample.Database;
using Purkki.MediatorCacheExample.Database.Entities;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
	{
		private readonly ExampleContext _context;

		public CreateCarCommandHandler(ExampleContext context)
		{
			_context = context;
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

			return car.Id;
		}
	}
}
