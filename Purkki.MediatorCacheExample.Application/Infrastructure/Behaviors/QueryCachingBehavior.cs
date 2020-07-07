using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Infrastructure.Behaviors
{
	public class QueryCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableQuery<TResponse>
	{
		private readonly IMemoryCache cache;

		public QueryCachingBehavior(IMemoryCache cache)
		{
			this.cache = cache;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var cacheKey = typeof(TRequest).Name + JsonSerializer.Serialize(request);
			var cacheResult = cache.Get<TResponse>(cacheKey);
			if (cacheResult != null)
			{
				return cacheResult;
			}

			var response = await next();
			cache.Set(cacheKey, response, DateTimeOffset.UtcNow.Add(request.Expiration));
			return response;
		}
	}

}
