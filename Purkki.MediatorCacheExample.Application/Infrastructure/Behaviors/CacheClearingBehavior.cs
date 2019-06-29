using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar;
using Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar;
using Purkki.MediatorCacheExample.Application.Cars.Queries.GetCars;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.Application.Infrastructure.Behaviors
{
	public class CacheClearingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
	{
		private readonly IMemoryCache _cache;

		public CacheClearingBehavior(IMemoryCache cache)
		{
			_cache = cache;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var response = await next();

			switch (request)
			{
				case CreateCarCommand _:
				case DeleteCarCommand _:
					var cacheKey = typeof(GetCarsQuery).ToString() + JsonConvert.SerializeObject(new GetCarsQuery());
					_cache.Remove(cacheKey);
					break;
			}

			return response;
		}
	}
}
