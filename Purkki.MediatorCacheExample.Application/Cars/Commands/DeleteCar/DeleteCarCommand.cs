using Purkki.MediatorCacheExample.Application.Infrastructure;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommand : ICommand
	{
		public int Id { get; set; }
	}
}
