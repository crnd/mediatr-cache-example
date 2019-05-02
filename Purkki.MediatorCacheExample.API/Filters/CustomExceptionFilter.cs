using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Purkki.MediatorCacheExample.Application.Infrastructure.Exceptions;
using System.Net;
using System.Net.Mime;

namespace Purkki.MediatorCacheExample.API.Filters
{
	public class CustomExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			HttpStatusCode code;
			switch (context.Exception)
			{
				case NotFoundException ex:
					code = HttpStatusCode.NotFound;
					break;
				default:
					code = HttpStatusCode.InternalServerError;
					break;
			}

			context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
			context.HttpContext.Response.StatusCode = (int)code;
			if (context.Result == null)
			{
				context.Result = new JsonResult(context.Exception.Message);
			}
		}
	}
}
