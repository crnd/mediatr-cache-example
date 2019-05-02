using Purkki.MediatorCacheExample.Application.Infrastructure;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Collections.Generic;

namespace Purkki.MediatorCacheExample.Application.Cars.Queries.GetCars
{
	public class GetCarsQuery : ICacheableQuery<IEnumerable<Car>> { }
}
