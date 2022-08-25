using AutoMapper;
using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.Entities.Concrete;
using EmreUgur.BackedProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmreUgur.BackedProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [ApiKey]
    [Authorize()]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByColor([FromQuery] string color)
        {
            return Ok(_mapper.Map<List<CarListDto>>(await _carService.GetCarsByColorAsync(color)));
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> TurnOnOffHeadlight(CarTurnOnOffHeadlightDto model)
        {
            var car = await _carService.FindByIdAsync(model.Id);

            if (car != null)
            {
                car.IsHeadlightOn = model.IsHeadlightOn;

                var result = await _carService.UpdateAsync(car);

                if (result > 0)
                {
                    return Ok(model.IsHeadlightOn ? "Headlight turned on" : "Headlight turned off");
                }

                return BadRequest("Error");
            }

            return NotFound(model.Id);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Car>))]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.FindByIdAsync(id);

            if (car != null)
            {
                var result = await _carService.RemoveAsync(car);

                if (result > 0)
                {
                    return NoContent();
                }

                return BadRequest("Error");
            }

            return NotFound(id);
        }
    }
}
