using System;

namespace Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string entity, string id) : base($"Entity {entity} was not found with ID {id}.") { }
	}
}
