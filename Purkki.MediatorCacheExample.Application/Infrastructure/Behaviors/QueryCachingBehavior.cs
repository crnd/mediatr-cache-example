using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Infrastructure.Behaviors
{
	public class QueryCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableQuery<TResponse>
	{
		private readonly IMemoryCache _cache;

		public QueryCachingBehavior(IMemoryCache cache)
		{
			_cache = cache;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var cacheKey = typeof(TRequest).ToString() + JsonConvert.SerializeObject(request);
			var cacheResult = _cache.Get<TResponse>(cacheKey);
			if (cacheResult != null)
			{
				return cacheResult;
			}

			var response = await next();
			_cache.Set(cacheKey, response, TimeSpan.FromMinutes(1));
			return response;
		}
	}
}
