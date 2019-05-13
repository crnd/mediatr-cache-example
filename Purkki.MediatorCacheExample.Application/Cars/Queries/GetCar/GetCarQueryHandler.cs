using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using Purkki.MediatorCacheExample.Database;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Queries.GetCar
{
	public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Car>
	{
		private readonly ExampleContext _context;

		public GetCarQueryHandler(ExampleContext context)
		{
			_context = context;
		}

		public async Task<Car> Handle(GetCarQuery request, CancellationToken cancellationToken)
		{
			var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
			if (car == null)
			{
				throw new NotFoundException(nameof(car), request.Id.ToString());
			}

			return car;
		}
	}
}
