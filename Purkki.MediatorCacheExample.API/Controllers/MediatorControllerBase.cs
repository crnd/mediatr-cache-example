using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Purkki.MediatorCacheExample.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class MediatorControllerBase : ControllerBase
	{
		private IMediator _mediator;

		protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
	}
}
