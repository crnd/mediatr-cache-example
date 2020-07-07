using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Purkki.MediatorCacheExample.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public abstract class MediatorControllerBase : ControllerBase
	{
		private IMediator mediator;

		protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
