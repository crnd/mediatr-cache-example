using Purkki.MediatorCacheExample.Application.Infrastructure;
using Purkki.MediatorCacheExample.Database.Entities;

namespace Purkki.MediatorCacheExample.Application.Cars.Queries.GetCar
{
	public class GetCarQuery : IQuery<Car>
	{
		public int Id { get; set; }
	}
}
