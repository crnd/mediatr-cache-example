using Purkki.MediatorCacheExample.Application.Infrastructure;
using Purkki.MediatorCacheExample.Database.Entities;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommand : ICommand<Car>
	{
		public string Make { get; set; }
		public string Model { get; set; }
	}
}
