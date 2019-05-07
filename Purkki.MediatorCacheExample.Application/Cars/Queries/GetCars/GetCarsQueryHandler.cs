using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Database;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Queries.GetCars
{
	public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<Car>>
	{
		private readonly ExampleContext _context;

		public GetCarsQueryHandler(ExampleContext context)
		{
			_context = context;
		}

		public async Task<List<Car>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
		{
			return await _context.Cars.ToListAsync(cancellationToken);
		}
	}
}
