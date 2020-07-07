using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using Purkki.MediatorCacheExample.Database.Entities;

namespace Purkki.MediatorCacheExample.Application.Cars.Exceptions
{
	public class CarNotFoundException : EntityNotFoundException
	{
		public CarNotFoundException(int id) : base(typeof(Car), id)
		{
		}
	}
}
