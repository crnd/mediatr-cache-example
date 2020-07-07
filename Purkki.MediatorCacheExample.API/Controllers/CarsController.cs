using Microsoft.AspNetCore.Mvc;
using Purkki.MediatorCacheExample.Application.Cars.Commands.CreateCar;
using Purkki.MediatorCacheExample.Application.Cars.Commands.DeleteCar;
using Purkki.MediatorCacheExample.Application.Cars.Queries.GetCar;
using Purkki.MediatorCacheExample.Application.Cars.Queries.GetCars;
using Purkki.MediatorCacheExample.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Purkki.MediatorCacheExample.API.Controllers
{
	public class CarsController : MediatorControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<Car>>> GetCars()
		{
			return await Mediator.Send(new GetCarsQuery());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Car>> GetCar(int id)
		{
			return await Mediator.Send(new GetCarQuery { Id = id });
		}

		[HttpPost]
		public async Task<ActionResult> CreateCar(CreateCarCommand command)
		{
			var car = await Mediator.Send(command);
			return CreatedAtAction(nameof(GetCar), new { car.Id }, car);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCar(int id)
		{
			await Mediator.Send(new DeleteCarCommand { Id = id });
			return NoContent();
		}
	}
}
