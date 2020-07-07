using System;

namespace Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		protected EntityNotFoundException(Type entity, int id) : base($"{entity.Name} was not found with ID {id}.") { }
	}
}
