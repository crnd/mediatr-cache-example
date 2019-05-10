using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Purkki.MediatorCacheExample.Application.Cars.Queries.GetCars;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Cars.Notifications
{
	public class ClearCarsCacheEntryNotificationHandler : INotificationHandler<ClearCarsCacheEntryNotification>
	{
		private readonly IMemoryCache _cache;
		private static readonly string _cacheKey = typeof(GetCarsQuery).ToString() + JsonConvert.SerializeObject(new GetCarsQuery());

		public ClearCarsCacheEntryNotificationHandler(IMemoryCache cache)
		{
			_cache = cache;
		}

		public Task Handle(ClearCarsCacheEntryNotification notification, CancellationToken cancellationToken)
		{
			Task.Run(() => _cache.Remove(_cacheKey));
			return Task.CompletedTask;
		}
	}
}
