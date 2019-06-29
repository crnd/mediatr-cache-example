using MediatR;
using Purkki.MediatorCacheExample.Application.Infrastructure;

namespace Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommand : ICommand<Unit>
	{
		public int Id { get; set; }
	}
}
