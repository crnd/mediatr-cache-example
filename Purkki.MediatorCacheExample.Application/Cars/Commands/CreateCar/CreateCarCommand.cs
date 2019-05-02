using Purkki.MediatorCacheExample.Application.Infrastructure;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommand : ICommand<int>
	{
		public string Make { get; set; }
		public string Model { get; set; }
	}
}
