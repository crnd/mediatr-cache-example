using System;

namespace Purkki.MediatorCacheExample.Application.Infrastructure
{
	public interface ICacheableQuery<T> : IQuery<T>
	{
		public TimeSpan Expiration => TimeSpan.FromMinutes(1);
	}
}
